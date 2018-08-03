using Newtonsoft.Json;
using System;

namespace Bitmex.NET.Dtos
{
    public class StatsHistoryDto
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("volume")]
        public decimal? Volume { get; set; }

        [JsonProperty("turnover")]
        public decimal? Turnover { get; set; }
    }
}
