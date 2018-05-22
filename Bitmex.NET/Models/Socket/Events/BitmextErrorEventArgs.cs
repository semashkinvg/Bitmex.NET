using System;

namespace Bitmex.NET.Models.Socket.Events
{
	public class BitmextErrorEventArgs : EventArgs
	{
		public Exception Exception { get; }

		public BitmextErrorEventArgs(Exception exception)
		{
			Exception = exception;
		}

	}
}
