using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace Bitmex.NET.Dtos
{
    public class StatsHistoryUsdDto
    {
        [JsonProperty("rootSymbol")]
        public string RootSymbol { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("turnover24h")]
        public decimal? Turnover24h { get; set; }

        [JsonProperty("turnover30d")]
        public decimal? Turnover30d { get; set; }

        [JsonProperty("turnover365d")]
        public decimal? Turnover365d { get; set; }

        [JsonProperty("turnover")]
        public decimal? Turnover { get; set; }

       
  

    }
}
