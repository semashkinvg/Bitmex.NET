using Newtonsoft.Json;

namespace Bitmex.NET.Models.Socket
{
    public class BitmexWebSocketConnectionLimitMessage
    {
        [JsonProperty("remaining")]
        public int Remaining { get; set; }
    }
}
