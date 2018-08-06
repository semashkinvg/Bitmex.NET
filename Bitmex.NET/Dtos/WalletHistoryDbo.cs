using System;

namespace Bitmex.NET.Dtos
{
    public class WalletHistoryDbo
    {
        public string TransactId { get; set; }
        public decimal? Account { get; set; }
        public string Currency { get; set; }
        public string TransactType { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Fee { get; set; }
        public string TransactStatus { get; set; }
        public string Address { get; set; }
        public string Tx { get; set; }
        public string Text { get; set; }
        public DateTime? TransactTime { get; set; }
        public DateTime? Timestamp { get; set; }

    }
}
