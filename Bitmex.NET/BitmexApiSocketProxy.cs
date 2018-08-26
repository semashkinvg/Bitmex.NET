using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Logging;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using System;
using System.Linq;
using System.Threading;
using WebSocket4Net;
using DataEventArgs = Bitmex.NET.Models.Socket.Events.DataEventArgs;

namespace Bitmex.NET
{
    public interface IBitmexApiSocketProxy : IDisposable
    {
        event SocketDataEventHandler DataReceived;
        event OperationResultEventHandler OperationResultReceived;
        event BitmextErrorEventHandler ErrorReceived;
        event BitmexCloseEventHandler Closed;
        bool Connect();
        void Send<TMessage>(TMessage message)
            where TMessage : SocketMessage;
        bool IsAlive { get; }
    }

    public class BitmexApiSocketProxy : IBitmexApiSocketProxy
    {
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();
        private const int SocketMessageResponseTimeout = 10000;
        private readonly ManualResetEvent _welcomeReceived = new ManualResetEvent(false);
        private readonly IBitmexAuthorization _bitmexAuthorization;
        public event SocketDataEventHandler DataReceived;
        public event OperationResultEventHandler OperationResultReceived;
        public event BitmextErrorEventHandler ErrorReceived;
        public event BitmexCloseEventHandler Closed;
        private WebSocket _socketConnection;

        public bool IsAlive => _socketConnection?.State == WebSocketState.Open;

        public BitmexApiSocketProxy(IBitmexAuthorization bitmexAuthorization)
        {
            _bitmexAuthorization = bitmexAuthorization;
        }

        public bool Connect()
        {
            CloseConnectionIfItsNotNull();
            _socketConnection = new WebSocket($"wss://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}/realtime") { EnableAutoSendPing = true, AutoSendPingInterval = 2 };
            BitmexWelcomeMessage welcomeData = null;
            EventHandler<MessageReceivedEventArgs> welcomeMessageReceived = (sender, e) =>
            {
                Log.Debug($"Welcome Data Received {e.Message}");
                welcomeData = JsonConvert.DeserializeObject<BitmexWelcomeMessage>(e.Message);
                _welcomeReceived.Set();
            };
            _socketConnection.MessageReceived += welcomeMessageReceived;
            _socketConnection.Open();
            var waitResult = _welcomeReceived.WaitOne(SocketMessageResponseTimeout);
            _socketConnection.MessageReceived -= welcomeMessageReceived;
            if (waitResult && (welcomeData?.Limit?.Remaining ?? 0) == 0)
            {
                Log.Error("Bitmext connection limit reached");
                throw new BitmexWebSocketLimitReachedException();
            }

            if (!waitResult)
            {
                Log.Error("Open connection timeout. Welcome message is not received");
                return false;
            }

            if (IsAlive)
            {
                Log.Info("Bitmex web socket connection opened");
                _socketConnection.MessageReceived += SocketConnectionOnMessageReceived;
                _socketConnection.Closed += SocketConnectionOnClosed;
                _socketConnection.Error += SocketConnectionOnError;
            }

            return IsAlive;
        }

        private void CloseConnectionIfItsNotNull()
        {
            if (_socketConnection != null)
            {
                Log.Debug("Closing existing connection");
                using (_socketConnection)
                {
                    _socketConnection.MessageReceived -= SocketConnectionOnMessageReceived;
                    _socketConnection.Closed -= SocketConnectionOnClosed;
                    _socketConnection.Error -= SocketConnectionOnError;
                    _welcomeReceived.Reset();
                    _socketConnection.Close();
                    _socketConnection = null;
                }
            }
        }

        private void SocketConnectionOnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Log.Debug($"Message received {e.Message}");
            var operationResult = JsonConvert.DeserializeObject<BitmexSocketOperationResultDto>(e.Message);
            if (operationResult.Request?.Operation != null && (operationResult.Request?.Arguments?.Any() ?? false))
            {
                OnOperationResultReceived(new OperationResultEventArgs(operationResult.Request.Operation.Value, operationResult.Success, operationResult.Error, operationResult.Status, operationResult.Request.Arguments));
                return;
            }

            var data = JsonConvert.DeserializeObject<BitmexSocketDataDto>(e.Message);
            if (!string.IsNullOrWhiteSpace(data.TableName) && (data.AdditionalData?.ContainsKey("data") ?? false))
            {
                OnDataReceived(new DataEventArgs(data.TableName, data.AdditionalData["data"], data.Action));
                return;
            }
        }

        private void SocketConnectionOnError(object sender, ErrorEventArgs e)
        {
            OnErrorReceived(e);
        }


        private void SocketConnectionOnClosed(object sender, EventArgs e)
        {
            OnClosed();
        }

        public void Send<TMessage>(TMessage message)
            where TMessage : SocketMessage
        {
            var json = JsonConvert.SerializeObject(message);
            Log.Debug($"Sending message {json}");
            _socketConnection.Send(json);
        }

        protected virtual void OnDataReceived(DataEventArgs args)
        {
            DataReceived?.Invoke(args);
        }

        protected virtual void OnOperationResultReceived(OperationResultEventArgs args)
        {
            OperationResultReceived?.Invoke(args);
        }

        protected virtual void OnErrorReceived(ErrorEventArgs args)
        {
            Log.Error(args.Exception, "Socket connection");
            ErrorReceived?.Invoke(new BitmextErrorEventArgs(args.Exception));
        }

        protected virtual void OnClosed()
        {
            Log.Debug("Connection closed");
            Closed?.Invoke(new BitmexCloseEventArgs());
        }

        public void Dispose()
        {
            CloseConnectionIfItsNotNull();
            _welcomeReceived?.Dispose();
            _socketConnection?.Dispose();
            Log.Info("Disposed...");
        }
    }
}
