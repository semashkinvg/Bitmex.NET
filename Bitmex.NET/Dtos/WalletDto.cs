using System;
using System.Collections.Generic;

namespace Bitmex.NET.Dtos
{
    public class WalletDto
    {
        public decimal? Account { get; set; }
        public string Currency { get; set; }
        public decimal? PrevDeposited { get; set; }
        public decimal? PrevWithdrawn { get; set; }
        public decimal? PrevTransferIn { get; set; }
        public decimal? PrevTransferOut { get; set; }
        public decimal? PrevAmount { get; set; }
        public DateTime? PrevTimestamp { get; set; }
        public decimal? DeltaDeposited { get; set; }
        public decimal? DeltaWithdrawn { get; set; }
        public decimal? DeltaTransferIn { get; set; }
        public decimal? DeltaTransferOut { get; set; }
        public decimal? DeltaAmount { get; set; }
        public decimal? Deposited { get; set; }
        public decimal? Withdrawn { get; set; }
        public decimal? TransferIn { get; set; }
        public decimal? TransferOut { get; set; }
        public decimal? Amount { get; set; }
        public decimal? PendingCredit { get; set; }
        public decimal? PendingDebit { get; set; }
        public decimal? ConfirmedDebit { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Addr { get; set; }
        public string Script { get; set; }
        public List<string> WithdrawalLock { get; set; }

    }
}
