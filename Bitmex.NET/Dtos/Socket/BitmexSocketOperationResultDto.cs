using Newtonsoft.Json;

namespace Bitmex.NET.Dtos.Socket
{
	public class BitmexSocketOperationResultDto
	{
		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("request")]
		public InitialRequstInfoDto Request { get; set; }
	}
}
