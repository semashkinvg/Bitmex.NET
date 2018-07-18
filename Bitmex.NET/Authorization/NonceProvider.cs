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
            var yearBegin = new DateTime(1970, 1, 1);
            var newNonce = Convert.ToInt64(Math.Floor((DateTime.UtcNow - yearBegin).TotalSeconds));
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
