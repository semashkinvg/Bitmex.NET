using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Bitmex.NET.Dtos.Socket
{
	public class BitmexSocketDataDto
	{
		[JsonProperty("table")]
		public string TableName { get; set; }

		[JsonProperty("action")]
		public string Action { get; set; }

		[JsonExtensionData]
		public IDictionary<string, JToken> AdditionalData { get; set; }
	}
}
