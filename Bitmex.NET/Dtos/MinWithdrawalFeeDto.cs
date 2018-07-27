using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
    public class MinWithdrawalFeeDto
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("fee", NullValueHandling = NullValueHandling.Ignore)]
        public long? Fee { get; set; }

        [JsonProperty("minFee", NullValueHandling = NullValueHandling.Ignore)]
        public long? MinFee { get; set; }
    }
}
