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
        private static long _lastNonce = DateTime.UtcNow.Ticks - new DateTime(2010, 1, 1).Ticks;

        public long GetNonce()
        {
            return Interlocked.Increment(ref _lastNonce);
        }
    }
}
