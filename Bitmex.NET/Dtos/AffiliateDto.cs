using System;

namespace Bitmex.NET.Dtos
{
    public class AffiliateDto
    {
        public decimal? Account { get; set; }
        public string Currency { get; set; }
        public decimal? PrevPayout { get; set; }
        public decimal? PrevTurnover { get; set; }
        public decimal? PrevComm { get; set; }
        public DateTime? PrevTimestamp { get; set; }
        public decimal? ExecTurnover { get; set; }
        public decimal? ExecComm { get; set; }
        public decimal? TotalReferrals { get; set; }
        public decimal? TotalTurnover { get; set; }
        public decimal? TotalComm { get; set; }
        public double? PayoutPcnt { get; set; }
        public decimal? PendingPayout { get; set; }
        public DateTime? Timestamp { get; set; }
        public double? ReferrerAccount { get; set; }

    }
}
