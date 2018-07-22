using Newtonsoft.Json;
using System;

namespace Bitmex.NET.Dtos.Socket
{
    public class OrderBook10Dto
    {
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("bids", NullValueHandling = NullValueHandling.Ignore)]
        public decimal[][] Bids { get; set; }

        [JsonProperty("asks", NullValueHandling = NullValueHandling.Ignore)]
        public decimal[][] Asks { get; set; }

        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Timestamp { get; set; }
    }
}
