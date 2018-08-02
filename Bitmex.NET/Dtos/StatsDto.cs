using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace Bitmex.NET.Dtos
{
    public class StatsDto
    {
        [JsonProperty("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("volume24h")]
        public decimal? Volume24H { get; set; }

        [JsonProperty("turnover24h")]
        public decimal? Turnover24H { get; set; }

        [JsonProperty("openInterest")]
        public decimal? OpenInterest { get; set; }

        [JsonProperty("openValue")]
        public decimal? OpenValue { get; set; }
    }
}
