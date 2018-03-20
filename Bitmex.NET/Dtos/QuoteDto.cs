using Newtonsoft.Json;
using System.Diagnostics;

namespace Bitmex.NET.Dtos
{
    [DebuggerDisplay("{Timestamp} {Symbol}")]
    public partial class QuoteDto
    {
        [JsonProperty("timestamp")]
        public System.DateTimeOffset? Timestamp { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("bidSize")]
        public double? BidSize { get; set; }

        [JsonProperty("bidPrice")]
        public double? BidPrice { get; set; }

        [JsonProperty("askPrice")]
        public long? AskPrice { get; set; }

        [JsonProperty("askSize")]
        public long? AskSize { get; set; }
    }
}
