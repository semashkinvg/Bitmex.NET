using System;
using System.Threading;

namespace Bitmex.NET.Authorization
{
	public interface INonceProvider
	{
		long GetNonce();
	}
	public class NonceProvider : INonceProvider
	{
		private static long _lastNonce = 0;
		public long GetNonce()
		{
			var yearBegin = new DateTime(1990, 1, 1);
			var newNonce = DateTime.UtcNow.Ticks - yearBegin.Ticks;
			if (_lastNonce < newNonce)
			{
				Interlocked.Exchange(ref _lastNonce, newNonce);
				return _lastNonce;
			}

			Interlocked.Increment(ref _lastNonce);
			return _lastNonce;
		}
	}
}
