using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
	public partial class OrderBookDto
	{
		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("side")]
		public string Side { get; set; }

		[JsonProperty("size")]
		public decimal Size { get; set; }

		[JsonProperty("price")]
		public decimal Price { get; set; }
	}
}
