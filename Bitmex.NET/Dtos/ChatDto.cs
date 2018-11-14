using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
    public class ChatDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("date")]
        public DateTime? Date { get; set; } = null;
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("html")]
        public string Html { get; set; }
        [JsonProperty("fromBot")]
        public bool? FromBot { get; set; }
        [JsonProperty("channelID")]
        public long? ChannelId { get; set; }
    
    }

    public class ChatConnectedDto
    {
        [JsonProperty("users")]
        public int? Users { get; set; }
        [JsonProperty("bots")]
        public int? Bots { get; set; }
    }


    public class ChatChannelDto
    {
        [JsonProperty("id")]
        public long? ChannelId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
