using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class NotificationDto
    {
        [JsonProperty("id")]
        public decimal? Id { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("ttl")]
        public decimal? Ttl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("closable")]
        public bool? Closable { get; set; }

        [JsonProperty("persist")]
        public bool? Persist { get; set; }

        [JsonProperty("waitForVisibility")]
        public bool? WaitForVisibility { get; set; }

        [JsonProperty("sound")]
        public string Sound { get; set; }
    }
}
