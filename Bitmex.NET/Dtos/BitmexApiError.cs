using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
	public partial class BitmexApiError
	{
		[JsonProperty("error")]
		public Error Error { get; set; }
	}

	public partial class Error
	{
		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
