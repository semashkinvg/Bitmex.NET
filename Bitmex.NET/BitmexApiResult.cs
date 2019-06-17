using System;

namespace Bitmex.NET
{
    public abstract class BitmexApiResultBase
    {
        /// <summary>
        /// Current rate limit
        /// </summary>
        public int RateLimitLimit { get; set; }

        /// <summary>
        /// Remaining requests
        /// </summary>
        public int RateLimitRemaining { get; set; }

        /// <summary>
        /// Time at which you will have enough requests left to retry your current request
        /// </summary>
        public DateTime RateLimitReset { get; set; }
    }

    public class BitmexApiResult<TResult> : BitmexApiResultBase
    {
        /// <summary>
        /// The result
        /// </summary>
        public TResult Result { get; set; }

        public BitmexApiResult()
        {

        }

        public BitmexApiResult(BitmexApiResultBase barb)
        {
            this.RateLimitLimit = barb.RateLimitLimit;
            this.RateLimitRemaining = barb.RateLimitRemaining;
            this.RateLimitReset = barb.RateLimitReset;
        }
    }
}
