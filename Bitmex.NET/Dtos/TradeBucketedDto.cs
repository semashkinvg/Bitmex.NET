using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
    public class TradeBucketedDto
    {
        [JsonProperty("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("open")]
        public decimal? Open { get; set; }

        [JsonProperty("high")]
        public decimal? High { get; set; }

        [JsonProperty("low")]
        public decimal? Low { get; set; }

        [JsonProperty("close")]
        public decimal? Close { get; set; }

		[JsonProperty("trades")]
		public decimal Trades { get; set; }

        [JsonProperty("volume")]
        public decimal? Volume { get; set; }

        [JsonProperty("vwap")]
        public decimal? Vwap { get; set; }

        [JsonProperty("lastSize")]
        public decimal? LastSize { get; set; }

		[JsonProperty("turnover")]
		public decimal Turnover { get; set; }

		[JsonProperty("homeNotional")]
		public decimal HomeNotional { get; set; }

		[JsonProperty("foreignNotional")]
		public decimal ForeignNotional { get; set; }
	}
}
