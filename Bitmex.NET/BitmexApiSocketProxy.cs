using System;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using SuperSocket.ClientEngine;
using WebSocket4Net;
using DataEventArgs = Bitmex.NET.Models.Socket.Events.DataEventArgs;

namespace Bitmex.NET
{
	public interface IBitmexApiSocketProxy
	{
		event SocketDataEventHandler DataReceived;
		event OperationResultEventHandler OperationResultReceived;
		bool Connect();
		void Send<TMessage>(TMessage message)
			where TMessage : SocketMessage;
		bool IsAlive { get; }
	}

	public class BitmexApiSocketProxy : IBitmexApiSocketProxy
	{
		private const int SocketMessageResponseTimeout = 30000;
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
			if (_socketConnection != null)
			{
				_socketConnection.MessageReceived -= SocketConnectionOnMessageReceived;
			    _socketConnection.Closed -= SocketConnectionOnClosed;
			    _socketConnection.Error -= SocketConnectionOnError;
                _welcomeReceived.Reset();
				_socketConnection.Close();
				_socketConnection = null;
			}

			_socketConnection = new WebSocket($"wss://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}/realtime");
			_socketConnection.MessageReceived += WellcomeMessageReceived;
            _socketConnection.Open();
			var waitResult = _welcomeReceived.WaitOne(SocketMessageResponseTimeout);
			if (!waitResult)
            {
				return false;
			}

			if (IsAlive)
			{
				_socketConnection.MessageReceived += SocketConnectionOnMessageReceived;
                _socketConnection.Closed += SocketConnectionOnClosed;
                _socketConnection.Error += SocketConnectionOnError;
            }

			return IsAlive;
		}

	    private void SocketConnectionOnMessageReceived(object sender, MessageReceivedEventArgs e)
	    {
	        var operationResult = JsonConvert.DeserializeObject<BitmexSocketOperationResultDto>(e.Message);
	        if (operationResult.Request?.Operation != null && (operationResult?.Request?.Arguments?.Any() ?? false))
	        {
	            OnOperationResultReceived(new OperationResultEventArgs(operationResult.Request.Operation.Value, operationResult.Success, operationResult.Error, operationResult.Status, operationResult.Request.Arguments));
	            return;
	        }

	        var data = JsonConvert.DeserializeObject<BitmexSocketDataDto>(e.Message);
	        if (!string.IsNullOrWhiteSpace(data.TableName) && (data.AdditionalData?.ContainsKey("data") ?? false))
	        {
	            OnDataReceived(new DataEventArgs(data.TableName, data.AdditionalData["data"]));
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
			_socketConnection.Send(JsonConvert.SerializeObject(message));
		}


		private void WellcomeMessageReceived(object sender, MessageReceivedEventArgs e)
        {
			_welcomeReceived.Set();
			_socketConnection.MessageReceived -= WellcomeMessageReceived;
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
            ErrorReceived?.Invoke(new BitmextErrorEventArgs(args.Exception));
        }

        protected virtual void OnClosed()
        {
            Closed?.Invoke(new BitmexCloseEventArgs());
        }
    }
}
