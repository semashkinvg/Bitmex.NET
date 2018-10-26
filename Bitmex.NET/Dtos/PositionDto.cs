using Newtonsoft.Json;
using System.Diagnostics;

namespace Bitmex.NET.Dtos
{
    [DebuggerDisplay("{Symbol} {ExecQty} Unr. P&L{UnrealisedPnl}")]
    public partial class PositionDto
    {
        [JsonProperty("account")]
        public long Account { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("underlying")]
        public string Underlying { get; set; }

        [JsonProperty("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("commission")]
        public decimal Commission { get; set; }

        [JsonProperty("initMarginReq")]
        public decimal InitMarginReq { get; set; }

        [JsonProperty("maintMarginReq")]
        public decimal MaintMarginReq { get; set; }

        [JsonProperty("riskLimit")]
        public decimal RiskLimit { get; set; }

        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }

        [JsonProperty("crossMargin")]
        public bool CrossMargin { get; set; }

        [JsonProperty("deleveragePercentile")]
        public decimal? DeleveragePercentile { get; set; }

        [JsonProperty("rebalancedPnl")]
        public decimal RebalancedPnl { get; set; }

        [JsonProperty("prevRealisedPnl")]
        public decimal PrevRealisedPnl { get; set; }

        [JsonProperty("prevUnrealisedPnl")]
        public decimal PrevUnrealisedPnl { get; set; }

        [JsonProperty("prevClosePrice")]
        public decimal PrevClosePrice { get; set; }

        [JsonProperty("openingTimestamp")]
        public System.DateTimeOffset OpeningTimestamp { get; set; }

        [JsonProperty("openingQty")]
        public decimal OpeningQty { get; set; }

        [JsonProperty("openingCost")]
        public decimal OpeningCost { get; set; }

        [JsonProperty("openingComm")]
        public decimal OpeningComm { get; set; }

        [JsonProperty("openOrderBuyQty")]
        public decimal OpenOrderBuyQty { get; set; }

        [JsonProperty("openOrderBuyCost")]
        public decimal OpenOrderBuyCost { get; set; }

        [JsonProperty("openOrderBuyPremium")]
        public decimal OpenOrderBuyPremium { get; set; }

        [JsonProperty("openOrderSellQty")]
        public decimal OpenOrderSellQty { get; set; }

        [JsonProperty("openOrderSellCost")]
        public decimal OpenOrderSellCost { get; set; }

        [JsonProperty("openOrderSellPremium")]
        public decimal OpenOrderSellPremium { get; set; }

        [JsonProperty("execBuyQty")]
        public decimal ExecBuyQty { get; set; }

        [JsonProperty("execBuyCost")]
        public decimal ExecBuyCost { get; set; }

        [JsonProperty("execSellQty")]
        public decimal ExecSellQty { get; set; }

        [JsonProperty("execSellCost")]
        public decimal ExecSellCost { get; set; }

        [JsonProperty("execQty")]
        public decimal ExecQty { get; set; }

        [JsonProperty("execCost")]
        public decimal ExecCost { get; set; }

        [JsonProperty("execComm")]
        public decimal ExecComm { get; set; }

        [JsonProperty("currentTimestamp")]
        public System.DateTimeOffset CurrentTimestamp { get; set; }

        [JsonProperty("currentQty")]
        public decimal CurrentQty { get; set; }

        [JsonProperty("currentCost")]
        public decimal CurrentCost { get; set; }

        [JsonProperty("currentComm")]
        public decimal? CurrentComm { get; set; }

        [JsonProperty("realisedCost")]
        public decimal RealisedCost { get; set; }

        [JsonProperty("unrealisedCost")]
        public decimal UnrealisedCost { get; set; }

        [JsonProperty("grossOpenCost")]
        public decimal GrossOpenCost { get; set; }

        [JsonProperty("grossOpenPremium")]
        public decimal GrossOpenPremium { get; set; }

        [JsonProperty("grossExecCost")]
        public decimal GrossExecCost { get; set; }

        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }

        [JsonProperty("markPrice")]
        public decimal? MarkPrice { get; set; }

        [JsonProperty("markValue")]
        public decimal MarkValue { get; set; }

        [JsonProperty("riskValue")]
        public decimal RiskValue { get; set; }

        [JsonProperty("homeNotional")]
        public decimal HomeNotional { get; set; }

        [JsonProperty("foreignNotional")]
        public decimal ForeignNotional { get; set; }

        [JsonProperty("posState")]
        public string PosState { get; set; }

        [JsonProperty("posCost")]
        public decimal PosCost { get; set; }

        [JsonProperty("posCost2")]
        public decimal PosCost2 { get; set; }

        [JsonProperty("posCross")]
        public decimal PosCross { get; set; }

        [JsonProperty("posInit")]
        public decimal PosInit { get; set; }

        [JsonProperty("posComm")]
        public decimal PosComm { get; set; }

        [JsonProperty("posLoss")]
        public decimal PosLoss { get; set; }

        [JsonProperty("posMargin")]
        public decimal PosMargin { get; set; }

        [JsonProperty("posMaint")]
        public decimal PosMaint { get; set; }

        [JsonProperty("posAllowance")]
        public decimal PosAllowance { get; set; }

        [JsonProperty("taxableMargin")]
        public decimal TaxableMargin { get; set; }

        [JsonProperty("initMargin")]
        public decimal InitMargin { get; set; }

        [JsonProperty("maintMargin")]
        public decimal MaintMargin { get; set; }

        [JsonProperty("sessionMargin")]
        public decimal SessionMargin { get; set; }

        [JsonProperty("targetExcessMargin")]
        public decimal TargetExcessMargin { get; set; }

        [JsonProperty("varMargin")]
        public decimal VarMargin { get; set; }

        [JsonProperty("realisedGrossPnl")]
        public decimal RealisedGrossPnl { get; set; }

        [JsonProperty("realisedTax")]
        public decimal RealisedTax { get; set; }

        [JsonProperty("realisedPnl")]
        public decimal RealisedPnl { get; set; }

        [JsonProperty("unrealisedGrossPnl")]
        public decimal UnrealisedGrossPnl { get; set; }

        [JsonProperty("longBankrupt")]
        public decimal LongBankrupt { get; set; }

        [JsonProperty("shortBankrupt")]
        public decimal ShortBankrupt { get; set; }

        [JsonProperty("taxBase")]
        public decimal TaxBase { get; set; }

        [JsonProperty("indicativeTaxRate")]
        public decimal? IndicativeTaxRate { get; set; }

        [JsonProperty("indicativeTax")]
        public decimal IndicativeTax { get; set; }

        [JsonProperty("unrealisedTax")]
        public decimal UnrealisedTax { get; set; }

        [JsonProperty("unrealisedPnl")]
        public decimal UnrealisedPnl { get; set; }

        [JsonProperty("unrealisedPnlPcnt")]
        public decimal UnrealisedPnlPcnt { get; set; }

        [JsonProperty("unrealisedRoePcnt")]
        public decimal UnrealisedRoePcnt { get; set; }

        [JsonProperty("avgCostPrice")]
        public decimal? AvgCostPrice { get; set; }

        [JsonProperty("avgEntryPrice")]
        public decimal? AvgEntryPrice { get; set; }

        [JsonProperty("breakEvenPrice")]
        public decimal? BreakEvenPrice { get; set; }

        [JsonProperty("marginCallPrice")]
        public decimal? MarginCallPrice { get; set; }

        [JsonProperty("liquidationPrice")]
        public decimal? LiquidationPrice { get; set; }

        [JsonProperty("bankruptPrice")]
        public decimal? BankruptPrice { get; set; }

        [JsonProperty("timestamp")]
        public System.DateTimeOffset Timestamp { get; set; }

        [JsonProperty("lastPrice")]
        public decimal? LastPrice { get; set; }

        [JsonProperty("lastValue")]
        public decimal LastValue { get; set; }
    }
}
