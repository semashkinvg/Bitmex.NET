using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
    public class TradeDto
    {
        [JsonProperty("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("size")]
        public decimal Size { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("tickDirection")]
        public string TickDirection { get; set; }

        [JsonProperty("trdMatchID")]
        public string TrdMatchId { get; set; }

        [JsonProperty("grossValue")]
        public decimal? GrossValue { get; set; }

        [JsonProperty("homeNotional")]
        public decimal HomeNotional { get; set; }

        [JsonProperty("foreignNotional")]
        public decimal ForeignNotional { get; set; }
    }
}
