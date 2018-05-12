using Bitmex.NET.Models.Socket;
using Newtonsoft.Json;

namespace Bitmex.NET.Dtos.Socket
{
	public class InitialRequstInfoDto
	{
		[JsonProperty("op")]
		public OperationType? Operation { get; set; }
		[JsonProperty("args")]
		public string[] Arguments { get; set; }
	}
}
