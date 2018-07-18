using Newtonsoft.Json;
using System;

namespace Bitmex.NET.Models.Socket
{
    public class BitmexWelcomeMessage
    {
        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("docs")]
        public string Docs { get; set; }

        [JsonProperty("limit")]
        public BitmexWebSocketConnectionLimitMessage Limit { get; set; }
    }
}
