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
        /// <summary>
        /// CIDR block to restrict this key to. To restrict to a single address, append "/32", e.g. 207.39.29.22/32. Leave blank or set to 0.0.0.0/0 to allow all IPs. Only one block may be set.
        /// </summary>
        [JsonProperty("cidr")]
        public string Cidr { get; set; }
        /// <summary>
        /// Key Permissions. All keys can read margin and position data. Additional permissions must be added. Available: ["order", "orderCancel", "withdraw"].
        /// </summary>
        [JsonProperty("permissions")]
        public string Permissions { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        /// <summary>
        /// OTP Token (YubiKey, Google Authenticator)
        /// </summary>
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
        public decimal Count { get; set; }

        [DisplayName("start")]
        public decimal Start { get; set; }

        [DisplayName("reverse")]
        public bool Reverse { get; set; }

        [DisplayName("channelID")]
        public decimal ChannelID { get; set; }
    }
    public partial class ChatPOSTRequestParams : QueryJsonParams
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("channelID")]
        public decimal ChannelID { get; set; }
    }
    public partial class ExecutionGETRequestParams : QueryStringParamsWithFilter
    {

        [DisplayName("symbol")]
        public string Symbol { get; set; }

        [DisplayName("columns")]
        public string Columns { get; set; }

        [DisplayName("count")]
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

        [DisplayName("reverse")]
        public bool Reverse { get; set; }

        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }

        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class FundingGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        ///Generic table filter. Send JSON key/value pairs, such as {"key": "value"}. 
        ///You can key on individual fields, and do more advanced querying on timestamps. See the Timestamp Docs for more details.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Array of column names to fetch. If omitted, will return all columns.
        /// Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }

        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }= null;

        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; } = null;
    }
    public partial class InstrumentGETRequestParams : QueryStringParamsWithFilter
    {

        [DisplayName("symbol")]
        public string Symbol { get; set; }
       
        [DisplayName("columns")]
        public string Columns { get; set; }

        [DisplayName("count")]
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

        [DisplayName("reverse")]
        public bool Reverse { get; set; } = false;

        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }

        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class InstrumentCompositeIndexGETRequestParams : QueryStringParamsWithFilter
    {

        [DisplayName("account")]
        public decimal? Account { get; set; }

        [DisplayName("symbol")]
        public string Symbol { get; set; }

        [DisplayName("columns")]
        public string Columns { get; set; }

        [DisplayName("count")]
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal Count { get; set; }

        [DisplayName("start")]
        public decimal Start { get; set; }

        [DisplayName("reverse")]
        public bool Reverse { get; set; }

        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }

        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
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
        public decimal Count { get; set; }

        [DisplayName("start")]
        public decimal Start { get; set; }

        [DisplayName("reverse")]
        public bool Reverse { get; set; }

        [DisplayName("startTime")]
        public DateTime StartTime { get; set; } //= DateTime.UtcNow.AddYears(-2);

        [DisplayName("endTime")]
        public DateTime EndTime { get; set; } = DateTime.UtcNow;
    }
    public partial class OrderGETRequestParams : QueryStringParamsWithFilter
    {

        [DisplayName("symbol")]
        public string Symbol { get; set; }

        [DisplayName("columns")]
        public string Columns { get; set; }

        [DisplayName("count")]
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal? SimpleOrderQty { get; set; }

        [JsonProperty("orderQty")]
        public decimal? OrderQty { get; set; }

        [JsonProperty("simpleLeavesQty")]
        public decimal? SimpleLeavesQty { get; set; }

        [JsonProperty("leavesQty")]
        public decimal? LeavesQty { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("stopPx")]
        public decimal? StopPx { get; set; }

        [JsonProperty("pegOffsetValue")]
        public decimal? PegOffsetValue { get; set; }

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
        public decimal? SimpleOrderQty { get; set; }

        [JsonProperty("orderQty")]
        public int? OrderQty { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("displayQty")]
        public decimal? DisplayQty { get; set; }

        [JsonProperty("stopPx")]
        public decimal? StopPx { get; set; }

        [JsonProperty("clOrdID")]
        public string ClOrdID { get; set; }

        [JsonProperty("clOrdLinkID")]
        public string ClOrdLinkID { get; set; }

        [JsonProperty("pegOffsetValue")]
        public decimal? PegOffsetValue { get; set; }

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
        public decimal? Price { get; set; }
    }
    public partial class OrderBookL2GETRequestParams : QueryStringParams
    {

        [DisplayName("symbol")]
        public string Symbol { get; set; }

        [DisplayName("depth")]
        public decimal? Depth { get; set; }
    }
    public partial class PositionGETRequestParams : QueryStringParamsWithFilter
    {

        [DisplayName("columns")]
        public string Columns { get; set; }

        [DisplayName("count")]
        public decimal? Count { get; set; }
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
        public decimal Leverage { get; set; }
    }
    public partial class PositionRiskLimitPOSTRequestParams : QueryJsonParams
    {

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("riskLimit")]
        public decimal RiskLimit { get; set; }
    }
    public partial class PositionTransferMarginPOSTRequestParams : QueryJsonParams
    {

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }   

    public partial class QuoteGETRequestParams : QueryStringParamsWithFilter
    {

        [DisplayName("symbol")]
        public string Symbol { get; set; }

        [DisplayName("columns")]
        public string Columns { get; set; }

        [DisplayName("count")]
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal Count { get; set; }

        [DisplayName("start")]
        public decimal Start { get; set; }

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
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal? Count { get; set; }

        [DisplayName("start")]
        public decimal? Start { get; set; }

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
        public decimal Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("fee")]
        public decimal Fee { get; set; }
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
