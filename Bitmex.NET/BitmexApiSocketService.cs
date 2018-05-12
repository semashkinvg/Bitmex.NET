using Bitmex.NET.Authorization;
using Bitmex.NET.Models.Socket;
using System;
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
		private const int SocketMessageResponseTimeout = 2000;

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
			OperationResultEventHandler resultReceived = args =>
			{
				if (args.OperationType == OperationType.authKey)
				{
					_isAuthorized = args.Result;
					respReceived.Set();
				}
			};

			var signatureString = _signatureProvider.CreateSignature(_bitmexAuthorization.Secret, $"GET/realtime{nonce}");
			var message = new SocketAuthorizationMessage(_bitmexAuthorization.Key, nonce, signatureString);
			_bitmexApiSocketProxy.OperationResultReceived += resultReceived;
			_bitmexApiSocketProxy.Send(message);
			respReceived.WaitOne(SocketMessageResponseTimeout);
			_bitmexApiSocketProxy.OperationResultReceived -= resultReceived;

			return _isAuthorized;
		}

		public void Subscribe<T>(BitmexApiSubscriptionInfo<T> subscription)
			where T : class
		{
			var message = new SocketSubscriptionMessage(subscription.SubscriptionName);
			var respReceived = new ManualResetEvent(false);
			bool success = false;
			string error = string.Empty;
			string status = string.Empty;
			OperationResultEventHandler resultReceived = args =>
			{
				if (args.OperationType == OperationType.subscribe)
				{
					error = args.Error;
					status = args.Status;
					success = args.Result;
					respReceived.Set();
				}
			};
			_bitmexApiSocketProxy.OperationResultReceived += resultReceived;
			_bitmexApiSocketProxy.Send(message);
			respReceived.WaitOne(SocketMessageResponseTimeout);
			_bitmexApiSocketProxy.OperationResultReceived -= resultReceived;
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
				throw new Exception("жопа");
			}
		}

		private void BitmexApiSocketProxyDataReceived(DataEventArgs args)
		{
			if (_actions.ContainsKey(args.TableName))
			{
				foreach (var subscription in _actions[args.TableName])
				{
					Task.Factory.StartNew(() => subscription.Execute(args.Data));
				}
			}
		}

		public static IBitmexApiSocketService CreateDefaultApi(IBitmexAuthorization bitmexAuthorization)
		{
			return new BitmexApiSocketService(bitmexAuthorization, new BitmexApiSocketProxy(bitmexAuthorization));
		}
	}
}
