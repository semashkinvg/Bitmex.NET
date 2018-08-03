using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitmex.NET.Dtos
{
    public class APIKeyDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("secret")]
        public string Secret { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("nonce")]
        public decimal? Nonce { get; set; }
        /// <summary>
        /// CIDR block to restrict this key to. To restrict to a single address, append "/32", e.g. 207.39.29.22/32. Leave blank or set to 0.0.0.0/0 to allow all IPs. Only one block may be set.
        /// </summary>
        [JsonProperty("cidr")]
        public string Cidr { get; set; }
        /// <summary>
        /// Key Permissions. All keys can read margin and position data. Additional permissions must be added. Available: ["order", "orderCancel", "withdraw"].
        /// </summary>
        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
        [JsonProperty("userId")]
        public decimal? UserId { get; set; }
        [JsonProperty("created")]
        public DateTime? Created { get; set; }
    }
}
