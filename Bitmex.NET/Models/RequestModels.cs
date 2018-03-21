using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Bitmex.NET.Models
{
	public partial class AnnouncementGETRequestParams : QueryStringParams
	{

		[DisplayName("columns")]
		public string Columns { get; set; }
	}
	public partial class ApiKeyGETRequestParams : QueryStringParams
	{

		[DisplayName("reverse")]
		public bool Reverse { get; set; }
	}
	public partial class ApiKeyPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("cidr")]
		public string Cidr { get; set; }

		[JsonProperty("permissions")]
		public string Permissions { get; set; }

		[JsonProperty("enabled")]
		public bool Enabled { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }
	}
	public partial class ApiKeyDELETERequestParams : QueryJsonParams
	{

		[JsonProperty("apiKeyID")]
		public string ApiKeyID { get; set; }
	}
	public partial class ApiKeyDisablePOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("apiKeyID")]
		public string ApiKeyID { get; set; }
	}
	public partial class ApiKeyEnablePOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("apiKeyID")]
		public string ApiKeyID { get; set; }
	}
	public partial class ChatGETRequestParams : QueryStringParams
	{

		[DisplayName("count")]
		public double Count { get; set; }

		[DisplayName("start")]
		public double Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("channelID")]
		public double ChannelID { get; set; }
	}
	public partial class ChatPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("channelID")]
		public double ChannelID { get; set; }
	}
	public partial class ExecutionGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class ExecutionTradeHistoryGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class FundingGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double Count { get; set; }

		[DisplayName("start")]
		public double Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime EndTime { get; set; }
	}
	public partial class InstrumentGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class InstrumentCompositeIndexGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("account")]
		public double? Account { get; set; }

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class InsuranceGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double Count { get; set; }

		[DisplayName("start")]
		public double Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime EndTime { get; set; }
	}
	public partial class LeaderboardGETRequestParams : QueryStringParams
	{

		[DisplayName("method")]
		public string Method { get; set; }
	}
	public partial class LiquidationGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double Count { get; set; }

		[DisplayName("start")]
		public double Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime EndTime { get; set; }
	}
	public partial class OrderGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class OrderPUTRequestParams : QueryJsonParams
	{

		[JsonProperty("orderID")]
		public string OrderID { get; set; }

		[JsonProperty("origClOrdID")]
		public string OrigClOrdID { get; set; }

		[JsonProperty("clOrdID")]
		public string ClOrdID { get; set; }

		[JsonProperty("simpleOrderQty")]
		public double? SimpleOrderQty { get; set; }

		[JsonProperty("orderQty")]
		public double? OrderQty { get; set; }

		[JsonProperty("simpleLeavesQty")]
		public double? SimpleLeavesQty { get; set; }

		[JsonProperty("leavesQty")]
		public double? LeavesQty { get; set; }

		[JsonProperty("price")]
		public double? Price { get; set; }

		[JsonProperty("stopPx")]
		public double? StopPx { get; set; }

		[JsonProperty("pegOffsetValue")]
		public double? PegOffsetValue { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
	public partial class OrderPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("side")]
		public string Side { get; set; }

		[JsonProperty("simpleOrderQty")]
		public double? SimpleOrderQty { get; set; }

		[JsonProperty("orderQty")]
		public int? OrderQty { get; set; }

		[JsonProperty("price")]
		public double? Price { get; set; }

		[JsonProperty("displayQty")]
		public double? DisplayQty { get; set; }

		[JsonProperty("stopPx")]
		public double? StopPx { get; set; }

		[JsonProperty("clOrdID")]
		public string ClOrdID { get; set; }

		[JsonProperty("clOrdLinkID")]
		public string ClOrdLinkID { get; set; }

		[JsonProperty("pegOffsetValue")]
		public double? PegOffsetValue { get; set; }

		[JsonProperty("pegPriceType")]
		public string PegPriceType { get; set; }

		[JsonProperty("ordType")]
		public string OrdType { get; set; }

		[JsonProperty("timeInForce")]
		public string TimeInForce { get; set; }

		[JsonProperty("execInst")]
		public string ExecInst { get; set; }

		[JsonProperty("contingencyType")]
		public string ContingencyType { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
	public partial class OrderDELETERequestParams : QueryJsonParams
	{

		[JsonProperty("orderID")]
		public string OrderID { get; set; }

		[JsonProperty("clOrdID")]
		public string ClOrdID { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
	public partial class OrderAllDELETERequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("filter")]
		public string Filter { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
	public partial class OrderBulkPUTRequestParams : QueryJsonParams
	{

		[JsonProperty("orders")]
		public OrderPUTRequestParams[] Orders { get; set; }
	}
	public partial class OrderBulkPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("orders")]
		public OrderPOSTRequestParams[] Orders { get; set; }
	}
	public partial class OrderCancelAllAfterPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("timeout")]
		public int Timeout { get; set; }
	}
	public partial class OrderClosePositionPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("price")]
		public double? Price { get; set; }
	}
	public partial class OrderBookL2GETRequestParams : QueryStringParams
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("depth")]
		public double? Depth { get; set; }
	}
	public partial class PositionGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }
	}
	public partial class PositionIsolatePOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("enabled")]
		public bool Enabled { get; set; }
	}
	public partial class PositionLeveragePOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("leverage")]
		public double Leverage { get; set; }
	}
	public partial class PositionRiskLimitPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("riskLimit")]
		public double RiskLimit { get; set; }
	}
	public partial class PositionTransferMarginPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("symbol")]
		public string Symbol { get; set; }

		[JsonProperty("amount")]
		public double Amount { get; set; }
	}
	public partial class QuoteGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class QuoteBucketedGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("binSize")]
		public string BinSize { get; set; }

		[DisplayName("partial")]
		public bool Partial { get; set; }

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class SchemaGETRequestParams : QueryStringParams
	{

		[DisplayName("model")]
		public string Model { get; set; }
	}
	public partial class SettlementGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double Count { get; set; }

		[DisplayName("start")]
		public double Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime EndTime { get; set; }
	}
	public partial class TradeGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class TradeBucketedGETRequestParams : QueryStringParamsWithFilter
	{

		[DisplayName("binSize")]
		public string BinSize { get; set; }

		[DisplayName("partial")]
		public bool Partial { get; set; }

		[DisplayName("symbol")]
		public string Symbol { get; set; }

		[DisplayName("columns")]
		public string Columns { get; set; }

		[DisplayName("count")]
		public double? Count { get; set; }

		[DisplayName("start")]
		public double? Start { get; set; }

		[DisplayName("reverse")]
		public bool Reverse { get; set; }

		[DisplayName("startTime")]
		public DateTime? StartTime { get; set; }

		[DisplayName("endTime")]
		public DateTime? EndTime { get; set; }
	}
	public partial class UserPUTRequestParams : QueryJsonParams
	{

		[JsonProperty("firstname")]
		public string Firstname { get; set; }

		[JsonProperty("lastname")]
		public string Lastname { get; set; }

		[JsonProperty("oldPassword")]
		public string OldPassword { get; set; }

		[JsonProperty("newPassword")]
		public string NewPassword { get; set; }

		[JsonProperty("newPasswordConfirm")]
		public string NewPasswordConfirm { get; set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("pgpPubKey")]
		public string PgpPubKey { get; set; }
	}
	public partial class UserCancelWithdrawalPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("token")]
		public string Token { get; set; }
	}
	public partial class UserCheckReferralCodeGETRequestParams : QueryStringParams
	{

		[DisplayName("referralCode")]
		public string ReferralCode { get; set; }
	}
	public partial class UserConfirmEmailPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("token")]
		public string Token { get; set; }
	}
	public partial class UserConfirmEnableTFAPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }
	}
	public partial class UserConfirmWithdrawalPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("token")]
		public string Token { get; set; }
	}
	public partial class UserDepositAddressGETRequestParams : QueryStringParams
	{

		[DisplayName("currency")]
		public string Currency { get; set; }
	}
	public partial class UserDisableTFAPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("token")]
		public string Token { get; set; }
	}
	public partial class UserMarginGETRequestParams : QueryStringParams
	{

		[DisplayName("currency")]
		public string Currency { get; set; }
	}
	public partial class UserMinWithdrawalFeeGETRequestParams : QueryStringParams
	{

		[DisplayName("currency")]
		public string Currency { get; set; }
	}
	public partial class UserPreferencesPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("prefs")]
		public string Prefs { get; set; }

		[JsonProperty("overwrite")]
		public bool Overwrite { get; set; }
	}
	public partial class UserRequestEnableTFAPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("type")]
		public string Type { get; set; }
	}
	public partial class UserRequestWithdrawalPOSTRequestParams : QueryJsonParams
	{

		[JsonProperty("otpToken")]
		public string OtpToken { get; set; }

		[JsonProperty("currency")]
		public string Currency { get; set; }

		[JsonProperty("amount")]
		public double Amount { get; set; }

		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("fee")]
		public double Fee { get; set; }
	}
	public partial class UserWalletGETRequestParams : QueryStringParams
	{

		[DisplayName("currency")]
		public string Currency { get; set; }
	}
	public partial class UserWalletHistoryGETRequestParams : QueryStringParams
	{

		[DisplayName("currency")]
		public string Currency { get; set; }
	}
	public partial class UserWalletSummaryGETRequestParams : QueryStringParams
	{

		[DisplayName("currency")]
		public string Currency { get; set; }
	}
}
