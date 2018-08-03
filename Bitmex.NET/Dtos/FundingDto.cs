using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class FundingDto
    {
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; } = null;      
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("fundingInterval")]
        public DateTime? FundingInterval { get; set; } = null;    
        [JsonProperty("fundingRate")]
        public double? FundingRate { get; set; }
        [JsonProperty("fundingRateDaily")]
        public double? FundingRateDaily { get; set; }
    }
}
