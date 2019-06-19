using System;

namespace Bitmex.NET
{
    public class BitmexApiResult<TResult>
    {
        /// <summary>
        /// The result
        /// </summary>
        public TResult Result { get; }

        /// <summary>
        /// Current rate limit
        /// </summary>
        public int RateLimitLimit { get; }

        /// <summary>
        /// Remaining requests
        /// </summary>
        public int RateLimitRemaining { get; }

        /// <summary>
        /// Time at which you will have enough requests left to retry your current request
        /// </summary>
        public DateTime RateLimitReset { get; }


        internal BitmexApiResult(TResult result)
        {
            this.Result = result;
        }

        internal BitmexApiResult(TResult result, int rateLimitLimit, int rateLimitRemaining, DateTime rateLimitReset) 
        {
            this.Result = result;
            this.RateLimitLimit = rateLimitLimit;
            this.RateLimitRemaining = rateLimitRemaining;
            this.RateLimitReset = rateLimitReset;
        }

        internal BitmexApiResult<T> ToResultType<T>(T result)
        {
            return new BitmexApiResult<T>(result, this.RateLimitLimit, this.RateLimitRemaining, this.RateLimitReset);
        }
    }
}
