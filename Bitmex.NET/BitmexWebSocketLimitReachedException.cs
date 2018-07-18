using System;

namespace Bitmex.NET
{
    public class BitmexWebSocketLimitReachedException : Exception
    {
        public BitmexWebSocketLimitReachedException() : base("remining connections count is 0")
        {

        }
    }
}
