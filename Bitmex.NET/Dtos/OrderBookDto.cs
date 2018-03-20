using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmex.NET.Dtos
{
    public partial class OrderBookDto
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }
    }
}
