using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmex.NET.Dtos
{
    public class TradeBucketedDto
    {
        [JsonProperty("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("open")]
        public long Open { get; set; }

        [JsonProperty("high")]
        public long High { get; set; }

        [JsonProperty("low")]
        public long Low { get; set; }

        [JsonProperty("close")]
        public long Close { get; set; }

        [JsonProperty("trades")]
        public long Trades { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }

        [JsonProperty("vwap")]
        public long Vwap { get; set; }

        [JsonProperty("lastSize")]
        public long LastSize { get; set; }

        [JsonProperty("turnover")]
        public long Turnover { get; set; }

        [JsonProperty("homeNotional")]
        public long HomeNotional { get; set; }

        [JsonProperty("foreignNotional")]
        public long ForeignNotional { get; set; }
    }
}
