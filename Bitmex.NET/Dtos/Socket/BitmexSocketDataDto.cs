using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bitmex.NET.Dtos.Socket
{
    [DebuggerDisplay("{" + nameof(TableName) + "} {" + nameof(Action) + "}")]
    public class BitmexSocketDataDto
    {
        [JsonProperty("table")]
        public string TableName { get; set; }

        [JsonProperty("action")]
        public BitmexActions Action { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> AdditionalData { get; set; }
    }
}
