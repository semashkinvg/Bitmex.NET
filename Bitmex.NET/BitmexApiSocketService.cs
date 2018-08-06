using Bitmex.NET.Authorization;
using Bitmex.NET.Logging;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bitmex.NET
{
    public interface IBitmexApiSocketService
    {
        /// <summary>
        /// Sends provided API key and a message encrypted using provided Secret to the server and waits for a response.
        /// </summary>
        /// <exception cref="BitmexSocketAuthorizationException">Throws when either timeout is reached or server retured an error.</exception>
        /// <returns>Returns value of IsAuthorized property.</returns>
        bool Connect();

        /// <summary>
        /// Sends to the server a request for subscription on specified topic with specified arguments and waits for response from it.
        /// If you ok to use provided DTO mdoels for socket communication please use <see cref="BitmetSocketSubscriptions"/> static methods to avoid Subscription->Model mapping mistakes.
        /// </summary>
        /// <exception cref="BitmexSocketSubscriptionException">Throws when either timeout is reached or server retured an error.</exception>
        /// <param name="subscription">Specific subscription details. Check out <see cref="BitmetSocketSubscriptions"/>.</param>
        void Subscribe(BitmexApiSubscriptionInfo subscription);

        void Unsubscribe(BitmexApiSubscriptionInfo subscription);

        Task UnsubscribeAsync(BitmexApiSubscriptionInfo subscription);
    }

    public class BitmexApiSocketService : IBitmexApiSocketService, IDisposable
    {
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();
        private const int SocketMessageResponseTimeout = 5000;

        private readonly IBitmexAuthorization _bitmexAuthorization;
        private readonly IExpiresTimeProvider _expiresTimeProvider;
        private readonly ISignatureProvider _signatureProvider;
        private readonly IBitmexApiSocketProxy _bitmexApiSocketProxy;
        private readonly IDictionary<string, IList<BitmexApiSubscriptionInfo>> _actions;

        private bool _isAuthorized;
        public bool IsAuthorized => _bitmexApiSocketProxy.IsAlive && _isAuthorized;

        public BitmexApiSocketService(IBitmexAuthorization bitmexAuthorization, IExpiresTimeProvider expiresTimeProvider, ISignatureProvider signatureProvider, IBitmexApiSocketProxy bitmexApiSocketProxy)
        {
            _bitmexAuthorization = bitmexAuthorization;
            _expiresTimeProvider = expiresTimeProvider;
            _signatureProvider = signatureProvider;
            _bitmexApiSocketProxy = bitmexApiSocketProxy;
            _actions = new Dictionary<string, IList<BitmexApiSubscriptionInfo>>();
            _bitmexApiSocketProxy.DataReceived += BitmexApiSocketProxyDataReceived;
        }

        public BitmexApiSocketService(IBitmexAuthorization bitmexAuthorization, IBitmexApiSocketProxy bitmexApiSocketProxy) : this(bitmexAuthorization, new ExpiresTimeProvider(), new SignatureProvider(), bitmexApiSocketProxy)
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
                Log.Info("WebSocket connection failed");
                return false;
            }

            return Authorize();
        }

        /// <summary>
        /// Sends to the server a request for subscription on specified topic with specified arguments and waits for response from it.
        /// If you ok to use provided DTO mdoels for socket communication please use <see cref="BitmetSocketSubscriptions"/> static methods to avoid Subscription->Model mapping mistakes.
        /// </summary>
        /// <exception cref="BitmexSocketSubscriptionException">Throws when either timeout is reached or server retured an error.</exception>
        /// <typeparam name="T">Expected type</typeparam>
        /// <param name="subscription">Specific subscription details. Check out <see cref="BitmetSocketSubscriptions"/>.</param>
        public void Subscribe(BitmexApiSubscriptionInfo subscription)
        {
            var subscriptionName = subscription.SubscriptionName;
            var message = new SocketSubscriptionMessage(subscription.SubscriptionWithArgs);
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
            Log.Info($"Subscribing on {subscriptionName}...");
            _bitmexApiSocketProxy.Send(message);
            var waitReuslt = respReceived.WaitOne(SocketMessageResponseTimeout);
            _bitmexApiSocketProxy.OperationResultReceived -= resultReceived;
            if (!waitReuslt)
            {
                throw new BitmexSocketSubscriptionException("Subscription failed: timeout waiting subscription response");
            }

            if (success)
            {

                Log.Info($"Successfully subscribed on {subscriptionName} ");
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
                Log.Error($"Failed to subscribe on {subscriptionName} {error} ");
                throw new BitmexSocketSubscriptionException(error, errorArgs);
            }
        }

        public async Task UnsubscribeAsync(BitmexApiSubscriptionInfo subscription)
        {
            var subscriptionName = subscription.SubscriptionName;
            var message = new SocketUnsubscriptionMessage(subscription.SubscriptionWithArgs);
            using (var semafore = new SemaphoreSlim(0, 1))
            {
                bool success = false;
                string error = string.Empty;
                string status = string.Empty;
                var errorArgs = new string[0];
                OperationResultEventHandler resultReceived = args =>
                {
                    if (args.OperationType == OperationType.unsubscribe)
                    {
                        error = args.Error;
                        status = args.Status;
                        success = args.Result;
                        errorArgs = args.Args;
                        semafore.Release(1);
                    }
                };
                _bitmexApiSocketProxy.OperationResultReceived += resultReceived;
                Log.Info($"Unsubscribing on {subscriptionName}...");
                _bitmexApiSocketProxy.Send(message);
                var waitReuslt = await semafore.WaitAsync(SocketMessageResponseTimeout);
                _bitmexApiSocketProxy.OperationResultReceived -= resultReceived;
                if (!waitReuslt)
                {
                    throw new BitmexSocketSubscriptionException("Unsubscription failed: timeout waiting unsubscription response");
                }

                if (success)
                {

                    Log.Info($"Successfully unsubscribed on {subscriptionName} ");
                    if (_actions.ContainsKey(subscription.SubscriptionName))
                    {
                        if (_actions[subscription.SubscriptionName].Contains(subscription))
                        {
                            _actions[subscription.SubscriptionName].Remove(subscription);
                        }
                    }
                }
                else
                {
                    Log.Error($"Failed to unsubscribe on {subscriptionName} {error} ");
                    throw new BitmexSocketSubscriptionException(error, errorArgs);
                }
            }
        }

        public void Unsubscribe(BitmexApiSubscriptionInfo subscription)
        {
            var task = UnsubscribeAsync(subscription);
            task.ConfigureAwait(false);
            task.Wait();
        }

        private bool Authorize()
        {
            var expiresTime = _expiresTimeProvider.Get();
            var respReceived = new ManualResetEvent(false);
            var data = new string[0];
            var error = string.Empty;
            OperationResultEventHandler resultReceived = args =>
            {
                if (args.OperationType == OperationType.authKeyExpires)
                {
                    _isAuthorized = args.Result;
                    error = args.Error;
                    data = args.Args;
                    respReceived.Set();
                }
            };

            var signatureString = _signatureProvider.CreateSignature(_bitmexAuthorization.Secret, $"GET/realtime{expiresTime}");
            var message = new SocketAuthorizationMessage(_bitmexAuthorization.Key, expiresTime, signatureString);
            _bitmexApiSocketProxy.OperationResultReceived += resultReceived;
            Log.Info("Authorizing...");
            _bitmexApiSocketProxy.Send(message);
            var waitResult = respReceived.WaitOne(SocketMessageResponseTimeout);
            _bitmexApiSocketProxy.OperationResultReceived -= resultReceived;
            if (!waitResult)
            {
                Log.Error("Timeout waiting authorization response");
                throw new BitmexSocketAuthorizationException("Authorization Failed: timeout waiting authorization response");
            }

            if (!IsAuthorized)
            {
                Log.Error($"Not authorized {error}");
                throw new BitmexSocketAuthorizationException(error, data);
            }

            Log.Info("Authorized successfully...");
            return IsAuthorized;
        }

        private void BitmexApiSocketProxyDataReceived(DataEventArgs args)
        {
            if (_actions.ContainsKey(args.TableName))
            {
                foreach (var subscription in _actions[args.TableName])
                {
                    var data = args.Data;
                    Task.Factory.StartNew(() => subscription.Execute(data, args.Action));
                }
            }
        }

        public static IBitmexApiSocketService CreateDefaultApi(IBitmexAuthorization bitmexAuthorization)
        {
            return new BitmexApiSocketService(bitmexAuthorization, new BitmexApiSocketProxy(bitmexAuthorization));
        }

        public void Dispose()
        {
            _bitmexApiSocketProxy?.Dispose();
            Log.Info("Disposed...");
        }
    }
}
