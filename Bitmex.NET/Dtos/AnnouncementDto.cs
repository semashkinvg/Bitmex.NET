using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class AnnouncementDto
    {
        [JsonProperty("id")]
        public decimal? Id { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }
    }
}
