using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class LeaderboardNameDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
