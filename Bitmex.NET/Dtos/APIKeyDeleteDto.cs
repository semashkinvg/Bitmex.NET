using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class APIKeyDeleteDto
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
