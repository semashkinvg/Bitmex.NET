using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
    public class TransactionDto
    {
        [JsonProperty("account", NullValueHandling = NullValueHandling.Ignore)]
        public long? Account { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("transactType", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactType { get; set; }

        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? Amount { get; set; }

        [JsonProperty("pendingDebit", NullValueHandling = NullValueHandling.Ignore)]
        public long? PendingDebit { get; set; }

        [JsonProperty("realisedPnl", NullValueHandling = NullValueHandling.Ignore)]
        public long? RealisedPnl { get; set; }

        [JsonProperty("walletBalance", NullValueHandling = NullValueHandling.Ignore)]
        public long? WalletBalance { get; set; }

        [JsonProperty("unrealisedPnl", NullValueHandling = NullValueHandling.Ignore)]
        public long? UnrealisedPnl { get; set; }

        [JsonProperty("marginBalance", NullValueHandling = NullValueHandling.Ignore)]
        public long? MarginBalance { get; set; }

    }
}
