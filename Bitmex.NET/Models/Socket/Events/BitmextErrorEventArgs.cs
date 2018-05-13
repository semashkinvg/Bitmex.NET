using System;

namespace Bitmex.NET.Models.Socket.Events
{
	public class BitmextErrorEventArgs : EventArgs
	{
		public string Message { get; }
		public Exception Exception { get; }

		public BitmextErrorEventArgs(string message, Exception exception)
		{
			Message = message;
			Exception = exception;
		}

	}
}
