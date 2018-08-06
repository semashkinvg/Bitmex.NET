using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class LiquidationDto
    {
        [JsonProperty("orderID")]
        public string OrderId { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("leavesQty")]
        public decimal? LeavesQty { get; set; }
    }
}
