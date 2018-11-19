using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitmex.NET.Dtos
{
    public class SchemaDto
    {
        [JsonProperty("keys")]
        public string[] Keys { get; set; }
        [JsonProperty("types")]
        public JObject Types { get; set; }

    }

    public class SchemaWebSocketHelpDto
    {

        [JsonProperty("info")]
        public string Info { get; set; }
        [JsonProperty("usage")]
        public string Usage { get; set; }
        [JsonProperty("ops")]
        public string[] Ops { get; set; }
        [JsonProperty("subscribe")]
        public string Subscribe { get; set; }
        [JsonProperty("subscriptionSubjects")]
        public Dictionary<string, string[]> SubscriptionSubjects { get; set; }
    }
}
