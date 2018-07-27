using System;

namespace Bitmex.NET.Dtos
{
    public class MarginDto
    {
        public decimal? Account { get; set; }
        public string Currency { get; set; }
        public decimal? RiskLimit { get; set; }
        public string PrevState { get; set; }
        public string State { get; set; }
        public string Action { get; set; }
        public decimal? Amount { get; set; }
        public decimal? PendingCredit { get; set; }
        public decimal? PendingDebit { get; set; }
        public decimal? ConfirmedDebit { get; set; }
        public decimal? PrevRealisedPnl { get; set; }
        public decimal? PrevUnrealisedPnl { get; set; }
        public decimal? GrossComm { get; set; }
        public decimal? GrossOpenCost { get; set; }
        public decimal? GrossOpenPremium { get; set; }
        public decimal? GrossExecCost { get; set; }
        public decimal? GrossMarkValue { get; set; }
        public decimal? RiskValue { get; set; }
        public decimal? TaxableMargin { get; set; }
        public decimal? InitMargin { get; set; }
        public decimal? MaintMargin { get; set; }
        public decimal? SessionMargin { get; set; }
        public decimal? TargetExcessMargin { get; set; }
        public decimal? VarMargin { get; set; }
        public decimal? RealisedPnl { get; set; }
        public decimal? UnrealisedPnl { get; set; }
        public decimal? IndicativeTax { get; set; }
        public decimal? UnrealisedProfit { get; set; }
        public decimal? SyntheticMargin { get; set; }
        public decimal? WalletBalance { get; set; }
        public decimal? MarginBalance { get; set; }
        public double? MarginBalancePcnt { get; set; }
        public double? MarginLeverage { get; set; }
        public double? MarginUsedPcnt { get; set; }
        public decimal? ExcessMargin { get; set; }
        public double? ExcessMarginPcnt { get; set; }
        public decimal? AvailableMargin { get; set; }
        public decimal? WithdrawableMargin { get; set; }
        public DateTime? Timestamp { get; set; }
        public decimal? GrossLastValue { get; set; }
        public double? Commission { get; set; }

    }
}
