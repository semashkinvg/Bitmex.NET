using System;

namespace Bitmex.NET.Models.Socket.Events
{
	public class BitmexCloseEventArgs : EventArgs
	{
		public ushort Code { get; }
		public string Reason { get; }
		public bool WasClean { get; }

		public BitmexCloseEventArgs(ushort code, string reason, bool wasClean)
		{
			Code = code;
			Reason = reason;
			WasClean = wasClean;
		}
	}
}
