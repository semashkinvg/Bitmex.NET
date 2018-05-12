using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
	public class InstrumentCompositeIndexDto
	{
		[JsonProperty("timestamp")]
		public System.DateTimeOffset? Timestamp { get; set; }

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("indexSymbol")]
		public string IndexSymbol { get; set; }

		[JsonProperty("reference")]
		public string Reference { get; set; }

		[JsonProperty("lastPrice")]
		public decimal? LastPrice { get; set; }

		[JsonProperty("weight")]
		public decimal? Weight { get; set; }

		[JsonProperty("logged")]
		public System.DateTimeOffset? Logged { get; set; }
	}
}
