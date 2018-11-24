using Newtonsoft.Json;

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
        public decimal? Price { get; set; }

        [JsonProperty("leavesQty")]
        public decimal? LeavesQty { get; set; }
    }
}