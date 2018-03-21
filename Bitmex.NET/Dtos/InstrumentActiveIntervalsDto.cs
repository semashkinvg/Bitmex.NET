using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
	public class InstrumentActiveIntervalsDto
	{
		[JsonProperty("intervals")]
		public string[] Intervals { get; set; }

		[JsonProperty("symbols")]
		public string[] Symbols { get; set; }
	}
}
