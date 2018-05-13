using Bitmex.NET.Authorization;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bitmex.NET
{
	public interface IBitmexApiSocketService
	{
		bool Connect();
		void Subscribe<T>(BitmexApiSubscriptionInfo<T> subscription)
			where T : class;
	}

	public class BitmexApiSocketService : IBitmexApiSocketService
	{
		private const int SocketMessageResponseTimeout = 5000;

		private readonly IBitmexAuthorization _bitmexAuthorization;
		private readonly INonceProvider _nonceProvider;
		private readonly ISignatureProvider _signatureProvider;
		private readonly IBitmexApiSocketProxy _bitmexApiSocketProxy;
		private readonly IDictionary<string, IList<BitmexApiSubscriptionInfo>> _actions;

		private bool _isAuthorized;
		public bool IsAuthorized => _bitmexApiSocketProxy.IsAlive && _isAuthorized;

		public BitmexApiSocketService(IBitmexAuthorization bitmexAuthorization, INonceProvider nonceProvider, ISignatureProvider signatureProvider, IBitmexApiSocketProxy bitmexApiSocketProxy)
		{
			_bitmexAuthorization = bitmexAuthorization;
			_nonceProvider = nonceProvider;
			_signatureProvider = signatureProvider;
			_bitmexApiSocketProxy = bitmexApiSocketProxy;
			_actions = new Dictionary<string, IList<BitmexApiSubscriptionInfo>>();
			_bitmexApiSocketProxy.DataReceived += BitmexApiSocketProxyDataReceived;
		}

		public BitmexApiSocketService(IBitmexAuthorization bitmexAuthorization, IBitmexApiSocketProxy bitmexApiSocketProxy) : this(bitmexAuthorization, new NonceProvider(), new SignatureProvider(), bitmexApiSocketProxy)
		{
		}

		/// <summary>
		/// Sends provided API key and a message encrypted using provided Secret to the server and waits for a response.
		/// </summary>
		/// <exception cref="BitmexSocketAuthorizationException">Throws when either timeout is reached or server retured an error.</exception>
		/// <returns>Returns value of IsAuthorized property.</returns>
		public bool Connect()
		{
			_isAuthorized = false;

			var connectionResult = _bitmexApiSocketProxy.Connect();
			if (!connectionResult)
			{
				return false;
			}

			return Authorize();
		}

		private bool Authorize()
		{
			var nonce = _nonceProvider.GetNonce();
			var respReceived = new ManualResetEvent(false);
			var data = new string[0];
			var error = string.Empty;
			OperationResultEventHandler resultReceived = args =>
			{
				if (args.OperationType == OperationType.authKey)
				{
					_isAuthorized = args.Result;
					error = args.Error;
					data = args.Args;
					respReceived.Set();
				}
			};

			var signatureString = _signatureProvider.CreateSignature(_bitmexAuthorization.Secret, $"GET/realtime{nonce}");
			var message = new SocketAuthorizationMessage(_bitmexAuthorization.Key, nonce, signatureString);
			_bitmexApiSocketProxy.OperationResultReceived += resultReceived;
			_bitmexApiSocketProxy.Send(message);
			var waitResult = respReceived.WaitOne(SocketMessageResponseTimeout);
			_bitmexApiSocketProxy.OperationResultReceived -= resultReceived;
			if (!waitResult)
			{
				throw new BitmexSocketAuthorizationException("Authorization Failed: timeout waiting authorization response");
			}

			if (!IsAuthorized)
			{
				throw new BitmexSocketAuthorizationException(error, data);
			}

			return IsAuthorized;
		}

		/// <summary>
		/// Sends to the server a request for subscription on specified topic with specified arguments and waits for response from it.
		/// </summary>
		/// <exception cref="BitmexSocketSubscriptionException">Throws when either timeout is reached or server retured an error.</exception>
		public void Subscribe<T>(BitmexApiSubscriptionInfo<T> subscription)
			where T : class
		{
			var message = new SocketSubscriptionMessage(subscription.SubscriptionName);
			var respReceived = new ManualResetEvent(false);
			bool success = false;
			string error = string.Empty;
			string status = string.Empty;
			var errorArgs = new string[0];
			OperationResultEventHandler resultReceived = args =>
			{
				if (args.OperationType == OperationType.subscribe)
				{
					error = args.Error;
					status = args.Status;
					success = args.Result;
					errorArgs = args.Args;
					respReceived.Set();
				}
			};
			_bitmexApiSocketProxy.OperationResultReceived += resultReceived;
			_bitmexApiSocketProxy.Send(message);
			var waitReuslt = respReceived.WaitOne(SocketMessageResponseTimeout);
			_bitmexApiSocketProxy.OperationResultReceived -= resultReceived;
			if (!waitReuslt)
			{
				throw new BitmexSocketSubscriptionException("Subscription failed: timeout waiting subscription response");
			}

			if (success)
			{

				if (!_actions.ContainsKey(subscription.SubscriptionName))
				{
					_actions.Add(subscription.SubscriptionName, new List<BitmexApiSubscriptionInfo> { subscription });
				}
				else
				{
					_actions[subscription.SubscriptionName].Add(subscription);
				}
			}
			else
			{
				throw new BitmexSocketSubscriptionException(error, errorArgs);
			}
		}

		private void BitmexApiSocketProxyDataReceived(DataEventArgs args)
		{
			if (_actions.ContainsKey(args.TableName))
			{
				foreach (var subscription in _actions[args.TableName])
				{
					var data = args.Data;
					Task.Factory.StartNew(() => subscription.Execute(data));
				}
			}
		}

		public static IBitmexApiSocketService CreateDefaultApi(IBitmexAuthorization bitmexAuthorization)
		{
			return new BitmexApiSocketService(bitmexAuthorization, new BitmexApiSocketProxy(bitmexAuthorization));
		}
	}
}
