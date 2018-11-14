using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
    public class SettlementDto
    {
        [JsonProperty("timestamp")]
        public DateTime? TimeStamp { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("settlementType")]
        public string SettlementType { get; set; }
        [JsonProperty("settledPrice")]
        public decimal? SettledPrice { get; set; }
        [JsonProperty("optionStrikePrice")]
        public decimal? OptionStrikePrice { get; set; }
        [JsonProperty("optionUnderlyingPrice")]
        public decimal? OptionUnderlyingPrice { get; set; }
        [JsonProperty("bankrupt")]
        public decimal? Bankrupt { get; set; }
        [JsonProperty("taxBase")]
        public decimal? TaxBase { get; set; }
        [JsonProperty("taxRate")]
        public decimal? TaxRate { get; set; }
    }
}
