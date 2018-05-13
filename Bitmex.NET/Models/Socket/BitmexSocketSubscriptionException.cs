using System;

namespace Bitmex.NET.Models.Socket
{
	public class BitmexSocketSubscriptionException : Exception
	{
		public BitmexSocketSubscriptionException(string msg) : base(msg)
		{

		}

		public BitmexSocketSubscriptionException(string srvMessage, string[] args) : base(
			$"Subscription Failed: {srvMessage} args: {string.Join(",", args)}")
		{

		}
	}
}
