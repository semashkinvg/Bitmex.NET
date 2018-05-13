using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using Bitmex.NET.Models.Socket.Events;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using WebSocketSharp;

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
		private const int SocketMessageResponseTimeout = 2000;
		private readonly ManualResetEvent _welcomeReceived = new ManualResetEvent(false);
		private readonly IBitmexAuthorization _bitmexAuthorization;
		public event SocketDataEventHandler DataReceived;
		public event OperationResultEventHandler OperationResultReceived;
		public event BitmextErrorEventHandler ErrorReceived;
		public event BitmexCloseEventHandler Closed;
		private WebSocket _socketConnection;

		public bool IsAlive => _socketConnection?.IsAlive ?? false;

		public BitmexApiSocketProxy(IBitmexAuthorization bitmexAuthorization)
		{
			_bitmexAuthorization = bitmexAuthorization;
		}

		public bool Connect()
		{
			if (_socketConnection?.IsAlive ?? false)
			{
				_socketConnection.OnMessage -= SocketConnectionOnMessage;
				_socketConnection.OnClose -= SocketConnectionOnClose;
				_socketConnection.OnError -= SocketConnectionOnError;
				_welcomeReceived.Reset();
				_socketConnection.Close(CloseStatusCode.Normal);
				_socketConnection = null;
			}

			_socketConnection = new WebSocket($"wss://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}/realtime");
			_socketConnection.OnMessage += WellcomeMessageReceived;
			_socketConnection.Connect();
			_socketConnection.OnMessage -= WellcomeMessageReceived;
			if (!_welcomeReceived.WaitOne(SocketMessageResponseTimeout))
			{
				return false;
			}

			if (IsAlive)
			{
				_socketConnection.OnMessage += SocketConnectionOnMessage;
				_socketConnection.OnClose += SocketConnectionOnClose;
				_socketConnection.OnError += SocketConnectionOnError;
			}

			return IsAlive;
		}

		private void SocketConnectionOnError(object sender, ErrorEventArgs e)
		{
			OnErrorReceived(e);
		}

		private void SocketConnectionOnClose(object sender, CloseEventArgs e)
		{
			OnClosed(e);
		}

		public void Send<TMessage>(TMessage message)
			where TMessage : SocketMessage
		{
			_socketConnection.Send(JsonConvert.SerializeObject(message));
		}

		private void SocketConnectionOnMessage(object sender, MessageEventArgs e)
		{
			var operationResult = JsonConvert.DeserializeObject<BitmexSocketOperationResultDto>(e.Data);
			if (operationResult.Request?.Operation != null && (operationResult?.Request?.Arguments?.Any() ?? false))
			{
				OnOperationResultReceived(new OperationResultEventArgs(operationResult.Request.Operation.Value, operationResult.Success, operationResult.Error, operationResult.Status, operationResult.Request.Arguments));
				return;
			}

			var data = JsonConvert.DeserializeObject<BitmexSocketDataDto>(e.Data);
			if (!string.IsNullOrWhiteSpace(data.TableName) && (data.AdditionalData?.ContainsKey("data") ?? false))
			{
				OnDataReceived(new DataEventArgs(data.TableName, data.AdditionalData["data"]));
			}
		}

		private void WellcomeMessageReceived(object sender, MessageEventArgs args)
		{
			_welcomeReceived.Set();
			_socketConnection.OnMessage -= WellcomeMessageReceived;
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
			ErrorReceived?.Invoke(new BitmextErrorEventArgs(args.Message, args.Exception));
		}

		protected virtual void OnClosed(CloseEventArgs args)
		{
			Closed?.Invoke(new BitmexCloseEventArgs(args.Code, args.Reason, args.WasClean));
		}
	}
}
