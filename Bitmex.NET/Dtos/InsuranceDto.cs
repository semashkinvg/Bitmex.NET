using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class InsuranceDto
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonProperty("walletBalance")]
        public decimal? WalletBalance { get; set; }
    }
}
