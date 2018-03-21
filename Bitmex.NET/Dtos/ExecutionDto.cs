using Newtonsoft.Json;

namespace Bitmex.NET.Dtos
{
	public class ExecutionDto
	{

		[JsonProperty("execID")]
		public string ExecId { get; set; }

		[JsonProperty("orderID")]
		public string OrderId { get; set; }

		[JsonProperty("clOrdID")]
		public string ClOrdId { get; set; }

		[JsonProperty("clOrdLinkID")]
		public string ClOrdLinkId { get; set; }

		[JsonProperty("account")]
		public long Account { get; set; }

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("side")]
		public string Side { get; set; }

		[JsonProperty("lastQty")]
		public long? LastQty { get; set; }

		[JsonProperty("lastPx")]
		public long? LastPx { get; set; }

		[JsonProperty("underlyingLastPx")]
		public long? UnderlyingLastPx { get; set; }

		[JsonProperty("lastMkt")]
		public string LastMkt { get; set; }

		[JsonProperty("lastLiquidityInd")]
		public string LastLiquidityInd { get; set; }

		[JsonProperty("simpleOrderQty")]
		public long? SimpleOrderQty { get; set; }

		[JsonProperty("orderQty")]
		public long? OrderQty { get; set; }

		[JsonProperty("price")]
		public long? Price { get; set; }

		[JsonProperty("displayQty")]
		public long? DisplayQty { get; set; }

		[JsonProperty("stopPx")]
		public long? StopPx { get; set; }

		[JsonProperty("pegOffsetValue")]
		public long? PegOffsetValue { get; set; }

		[JsonProperty("pegPriceType")]
		public string PegPriceType { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("settlCurrency")]
		public string SettlCurrency { get; set; }

		[JsonProperty("execType")]
		public string ExecType { get; set; }

		[JsonProperty("ordType")]
		public string OrdType { get; set; }

		[JsonProperty("timeInForce")]
		public string TimeInForce { get; set; }

		[JsonProperty("execInst")]
		public string ExecInst { get; set; }

		[JsonProperty("contingencyType")]
		public string ContingencyType { get; set; }

		[JsonProperty("exDestination")]
		public string ExDestination { get; set; }

		[JsonProperty("ordStatus")]
		public string OrdStatus { get; set; }

		[JsonProperty("triggered")]
		public string Triggered { get; set; }

		[JsonProperty("workingIndicator")]
		public bool WorkingIndicator { get; set; }

		[JsonProperty("ordRejReason")]
		public string OrdRejReason { get; set; }

		[JsonProperty("simpleLeavesQty")]
		public long SimpleLeavesQty { get; set; }

		[JsonProperty("leavesQty")]
		public long LeavesQty { get; set; }

		[JsonProperty("simpleCumQty")]
		public long SimpleCumQty { get; set; }

		[JsonProperty("cumQty")]
		public long CumQty { get; set; }

		[JsonProperty("avgPx")]
		public long? AvgPx { get; set; }

		[JsonProperty("commission")]
		public long? Commission { get; set; }

		[JsonProperty("tradePublishIndicator")]
		public string TradePublishIndicator { get; set; }

		[JsonProperty("multiLegReportingType")]
		public string MultiLegReportingType { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("trdMatchID")]
		public string TrdMatchId { get; set; }

		[JsonProperty("execCost")]
		public long? ExecCost { get; set; }

		[JsonProperty("execComm")]
		public long? ExecComm { get; set; }

		[JsonProperty("homeNotional")]
		public long? HomeNotional { get; set; }

		[JsonProperty("foreignNotional")]
		public long? ForeignNotional { get; set; }

		[JsonProperty("transactTime")]
		public System.DateTimeOffset TransactTime { get; set; }

		[JsonProperty("timestamp")]
		public System.DateTimeOffset Timestamp { get; set; }
	}
}
