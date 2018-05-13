using System;

namespace Bitmex.NET.Models.Socket
{
	public class BitmexSocketAuthorizationException : Exception
	{
		public BitmexSocketAuthorizationException(string msg) : base(msg)
		{

		}

		public BitmexSocketAuthorizationException(string srvMessage, string[] args) : base(
			$"Authorization Failed: {srvMessage} args: {string.Join(",", args)}")
		{

		}
	}
}
