using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Bitmex.NET.Models
{
    /// <summary>
    /// Get site announcements
    /// </summary>
    public partial class AnnouncementGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Array of column names to fetch. If omitted, will return all columns.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
    }
    /// <summary>
    /// Persistent API Keys for Developers
    /// </summary>
    public partial class ApiKeyGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
    }
    /// <summary>
    /// API Keys can only be created via the frontend.
    /// </summary>
    public partial class ApiKeyPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Key name. This name is for reference only.
        /// </summary>
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
        /// <summary>
        /// Set to true to enable this key on creation. Otherwise, it must be explicitly enabled via /apiKey/enable.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        /// <summary>
        /// OTP Token (YubiKey, Google Authenticator)
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    /// <summary>
    /// Delete an API key
    /// </summary>
    public partial class ApiKeyDELETERequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// API Key ID (public component).
        /// </summary>
        [DisplayName("apiKeyID")]
        public string ApiKeyID { get; set; }
    }
    /// <summary>
    /// Disable an API key
    /// </summary>
    public partial class ApiKeyDisablePOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// API Key ID (public component).
        /// </summary>
        [JsonProperty("apiKeyID")]
        public string ApiKeyID { get; set; }
    }
    /// <summary>
    /// Enable an API key
    /// </summary>
    public partial class ApiKeyEnablePOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// API Key ID (public component).
        /// </summary>
        [JsonProperty("apiKeyID")]
        public string ApiKeyID { get; set; }
    }
    /// <summary>
    /// Get chat messages
    /// </summary>
    public partial class ChatGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public int Count { get; set; }
        /// <summary>
        /// Starting ID for results.
        /// </summary>
        [DisplayName("start")]
        public long Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Channel id. GET /chat/channels for ids. Leave blank for all.
        /// </summary>
        [DisplayName("channelID")]
        public long ChannelID { get; set; }
    }
    /// <summary>
    /// Send message to Chat
    /// </summary>
    public partial class ChatPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Message to send
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        /// <summary>
        /// Channel to post to. Default 1 (English).
        /// </summary>
        [JsonProperty("channelID")]
        public long ChannelID { get; set; }
    }

    /// <summary>
    /// Get all raw executions for your account
    /// </summary>
    public partial class ExecutionGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
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
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class ExecutionTradeHistoryGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Array of column names to fetch. If omitted, will return all columns.Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
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
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class InstrumentGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        ///  Array of column names to fetch. If omitted, will return all columns.Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; } = false;
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class InstrumentCompositeIndexGETRequestParams : QueryStringParamsWithFilter
    {

        /// <summary>
        /// The composite index symbol. E.g. ".XBT"
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        ///  Array of column names to fetch. If omitted, will return all columns.Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class InsuranceGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        ///Array of column names to fetch.If omitted, will return all columns. Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
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
        ///If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        ///Starting date filter for results.
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// Get current leaderboard
    /// </summary>
    public partial class LeaderboardGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Ranking type.Options: "notional", "ROE"
        /// </summary>
        [DisplayName("method")]
        public string Method { get; set; }
    }
    /// <summary>
    /// Get liquidation orders
    /// </summary>
    public partial class LiquidationGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        ///  Array of column names to fetch. If omitted, will return all columns.Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
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
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// To get open orders only, send {"open": true} in the filter param. e.g. new Dictionary _string,string_(){{"open","true"}}
    /// </summary>
    public partial class OrderGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        ///  Array of column names to fetch. If omitted, will return all columns.Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// Send an orderID or origClOrdID to identify the order you wish to amend.
    /// Both order quantity and price can be amended.Only one qty field can be used to amend.
    /// Use the leavesQty field to specify how much of the order you wish to remain open.
    /// This can be useful if you want to adjust your position's delta by a certain amount, regardless of how much of the order has already filled.
    /// A leavesQty can be used to make a "Filled" order live again, if it is received within 60 seconds of the fill.
    /// Use the simpleOrderQty and simpleLeavesQty fields to specify order size in Bitcoin, rather than contracts.These fields will round up to the nearest contract.
    /// Like order placement, amending can be done in bulk.Simply send a request to PUT /api/v1/order/bulk with a JSON body of the shape: { "orders": [{...}, {...}]}, each object containing the fields used in this endpoint.
    /// </summary>
    public partial class OrderPUTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Order ID
        /// </summary>
        [JsonProperty("orderID")]
        public string OrderID { get; set; }
        /// <summary>
        /// Client Order ID.See POST /order.
        /// </summary>
        [JsonProperty("origClOrdID")]
        public string OrigClOrdID { get; set; }
        /// <summary>
        /// Optional new Client Order ID, requires origClOrdID.
        /// </summary>
        [JsonProperty("clOrdID")]
        public string ClOrdID { get; set; }
        /// <summary>
        /// Optional order quantity in units of the instrument (i.e. contracts).
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal? OrderQty { get; set; }

        [JsonProperty("displayQty")]
        public decimal? DisplayQty { get; set; }
        /// <summary>
        /// Optional leaves quantity in units of the instrument (i.e. contracts). Useful for amending partially filled orders.
        /// </summary>
        [JsonProperty("leavesQty")]
        public decimal? LeavesQty { get; set; }
        /// <summary>
        /// Optional limit price for 'Limit', 'StopLimit', and 'LimitIfTouched' orders.
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// Optional trigger price for 'Stop', 'StopLimit', 'MarketIfTouched', and 'LimitIfTouched' orders.Use a price below the current price for stop-sell orders and buy-if-touched orders.
        /// </summary>
        [JsonProperty("stopPx")]
        public decimal? StopPx { get; set; }
        /// <summary>
        /// Optional trailing offset from the current price for 'Stop', 'StopLimit', 'MarketIfTouched', and 'LimitIfTouched' orders; 
        /// use a negative offset for stop-sell orders and buy-if-touched orders. Optional offset from the peg price for 'Pegged' orders.
        /// </summary>
        [JsonProperty("pegOffsetValue")]
        public decimal? PegOffsetValue { get; set; }
        /// <summary>
        /// Optional amend annotation. e.g. 'Adjust skew'. 42
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    /// <summary>
    /// https://testnet.bitmex.com/api/explorer/#!/Order/Order_new
    /// </summary>
    public partial class OrderPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Instrument symbol. e.g. 'XBTUSD'.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Order side.Valid options: Buy, Sell.Defaults to 'Buy' unless orderQty or simpleOrderQty is negative.
        /// </summary>
        [JsonProperty("side")]
        public string Side { get; set; }
        /// <summary>
        /// Order quantity in units of the instrument (i.e. contracts).
        /// </summary>
        [JsonProperty("orderQty")]
        public decimal? OrderQty { get; set; }
        /// <summary>
        /// Optional limit price for 'Limit', 'StopLimit', and 'LimitIfTouched' orders.
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("displayQty")]
        public decimal? DisplayQty { get; set; }
        /// <summary>
        /// Optional quantity to display in the book. Use 0 for a fully hidden order.
        /// </summary>
        [JsonProperty("stopPx")]
        public decimal? StopPx { get; set; }
        /// <summary>
        /// Optional trigger price for 'Stop', 'StopLimit', 'MarketIfTouched', and 'LimitIfTouched' orders. 
        /// Use a price below the current price for stop-sell orders and buy-if-touched orders.
        /// Use execInst of 'MarkPrice' or 'LastPrice' to define the current price used for triggering.
        /// </summary>
        [JsonProperty("clOrdID")]
        public string ClOrdID { get; set; }
        /// <summary>
        /// Optional Client Order ID. This clOrdID will come back on the order and any related executions.
        /// </summary>
        [JsonProperty("clOrdLinkID")]
        public string ClOrdLinkID { get; set; }
        /// <summary>
        /// Optional trailing offset from the current price for 'Stop', 'StopLimit', 'MarketIfTouched', and 'LimitIfTouched' orders;
        /// use a negative offset for stop-sell orders and buy-if-touched orders. Optional offset from the peg price for 'Pegged' orders.
        /// </summary>
        [JsonProperty("pegOffsetValue")]
        public decimal? PegOffsetValue { get; set; }
        /// <summary>
        /// Optional peg price type. Valid options: LastPeg, MidPricePeg, MarketPeg, PrimaryPeg, TrailingStopPeg.
        /// </summary>
        [JsonProperty("pegPriceType")]
        public string PegPriceType { get; set; }
        /// <summary>
        /// Order type. Valid options: Market, Limit, Stop, StopLimit, MarketIfTouched, LimitIfTouched, MarketWithLeftOverAsLimit, Pegged. 
        /// Defaults to 'Limit' when price is specified. Defaults to 'Stop' when stopPx is specified. Defaults to 'StopLimit' when price and stopPx are specified.
        /// </summary>
        [JsonProperty("ordType")]
        public string OrdType { get; set; }
        /// <summary>
        /// Time in force. Valid options: Day, GoodTillCancel, ImmediateOrCancel, FillOrKill.
        /// Defaults to 'GoodTillCancel' for 'Limit', 'StopLimit', 'LimitIfTouched', and 'MarketWithLeftOverAsLimit' orders.
        /// </summary>
        [JsonProperty("timeInForce")]
        public string TimeInForce { get; set; }
        /// <summary>
        /// Optional execution instructions.Valid options: ParticipateDoNotInitiate, AllOrNone, MarkPrice, IndexPrice, LastPrice, Close, ReduceOnly, Fixed.
        /// 'AllOrNone' instruction requires displayQty to be 0. 'MarkPrice', 'IndexPrice' or 'LastPrice' instruction valid for 'Stop', 'StopLimit', 'MarketIfTouched', 
        /// and 'LimitIfTouched' orders.
        /// </summary>
        [JsonProperty("execInst")]
        public string ExecInst { get; set; }
        /// <summary>
        /// Optional order annotation. e.g. 'Take profit on MOON!'.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
    public partial class OrderDELETERequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Order ID(s).
        /// </summary>
        [DisplayName("orderID")]
        public string OrderID { get; set; }
        /// <summary>
        /// Client Order ID(s). See POST /order.
        /// </summary>
        [DisplayName("clOrdID")]
        public string ClOrdID { get; set; }
        /// <summary>
        /// Optional cancellation annotation. e.g. 'Spread Exceeded'.
        /// </summary>
        [DisplayName("text")]
        public string Text { get; set; }
    }
    /// <summary>
    /// Delete all orders
    /// </summary>
    public partial class OrderAllDELETERequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        ///  Optional symbol.If provided, only cancels orders for that symbol.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Optional filter for cancellation. Use to only cancel some orders, e.g. {"side": "Buy"}.
        /// </summary>
        [DisplayName("filter")]
        public string Filter { get; set; }
        /// <summary>        
        /// Optional cancellation annotation.e.g. 'Spread Exceeded'
        /// </summary>
        [DisplayName("text")]
        public string Text { get; set; }
    }
    /// <summary>
    /// Amend multiple orders for the same symbol.
    /// </summary>
    public partial class OrderBulkPUTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// List of orders to amend
        /// </summary>
        [JsonProperty("orders")]
        public OrderPUTRequestParams[] Orders { get; set; }
    }
    /// <summary>
    /// Create multiple new orders for the same symbol.
    /// </summary>
    public partial class OrderBulkPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// List of orders to create
        /// </summary>
        [JsonProperty("orders")]
        public OrderPOSTRequestParams[] Orders { get; set; }
    }
    /// <summary>
    /// Automatically cancel all your orders after a specified timeout.
    /// Useful as a dead-man's switch to ensure your orders are canceled in case of an outage. If called repeatedly, the existing offset will be canceled and a new one will be inserted in its place.
    /// Example usage: call this route at 15s intervals with an offset of 60000 (60s). If this route is not called within 60 seconds, all your orders will be automatically canceled.
    /// </summary>
    public partial class OrderCancelAllAfterPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Timeout in ms. Set to 0 to cancel this timer
        /// </summary>
        [JsonProperty("timeout")]
        public int Timeout { get; set; }
    }
    /// <summary>
    /// Close a position. [Deprecated, use POST /order with execInst: 'Close'
    /// </summary>
    [Obsolete]
    public partial class OrderClosePositionPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Symbol of position to close.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Optional limit price.
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }
    }
    public partial class OrderBookL2GETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Instrument symbol. Send a series (e.g. XBT) to get data for the nearest contract in that series.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Orderbook depth per side. Send 0 for full depth
        /// </summary>
        [DisplayName("depth")]
        public decimal? Depth { get; set; }
    }
    public partial class PositionGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        ///  Array of column names to fetch. If omitted, will return all columns.Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
    }
    public partial class PositionIsolatePOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Position symbol to isolate.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// True for isolated margin, false for cross margin.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
    public partial class PositionLeveragePOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Symbol of position to adjust.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Leverage value. Send a number between 0.01 and 100 to enable isolated margin with a fixed leverage. Send 0 to enable cross margin.
        /// </summary>
        [JsonProperty("leverage")]
        public decimal Leverage { get; set; }
    }
    public partial class PositionRiskLimitPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Symbol of position to update risk limit on.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// New Risk Limit, in Satoshis.
        /// </summary>
        [JsonProperty("riskLimit")]
        public decimal RiskLimit { get; set; }
    }
    public partial class PositionTransferMarginPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Symbol of position to isolate.
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Amount to transfer, in Satoshis. May be negative.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }

    public partial class QuoteGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// 	 Instrument symbol.Send a bare series (e.g.XBU) to get data for the nearest expiring contract in that series.
        /// 	 You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
        /// </summary>
        [DisplayName("symbol")]
        public string Symbol { get; set; }
        /// <summary>
        /// Array of column names to fetch. If omitted, will return all columns.   Note that this method will always return item keys, even when not specified, so you may receive more columns that you expect.
        /// </summary>
        [DisplayName("columns")]
        public string Columns { get; set; }
        /// <summary>
        /// Number of results to fetch.
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    public partial class QuoteBucketedGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Time interval to bucket by. Available options: [1m,5m,1h,1d].
        /// </summary>
        [DisplayName("binSize")]
        public string BinSize { get; set; }
        /// <summary>
        /// If true, will send in-progress(incomplete) bins for the current time period.
        /// </summary>
        [DisplayName("partial")]
        public bool Partial { get; set; }
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
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
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// Get model schemata for data objects returned by this API
    /// </summary>
    public partial class SchemaGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Optional model filter.If omitted, will return all models.
        /// </summary>
        [DisplayName("model")]
        public string Model { get; set; }
    }
    /// <summary>
    /// Get settlement history
    /// </summary>
    public partial class SettlementGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
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
        /// <summary>
        /// Starting date filter for results
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// Get trades. Please note that indices (symbols starting with .) post trades at intervals to the trade feed. These have a size of 0 and are used only to indicate a changing price.
    /// </summary>
    public partial class TradeGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
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
        /// Number of results to fetch
        /// </summary>
        [DisplayName("count")]
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results.
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// Get previous trades in time buckets
    /// </summary>
    public partial class TradeBucketedGETRequestParams : QueryStringParamsWithFilter
    {
        /// <summary>
        /// Time interval to bucket by. Available options: [1m,5m,1h,1d].
        /// </summary>
        [DisplayName("binSize")]
        public string BinSize { get; set; }
        /// <summary>
        /// If true, will send in-progress (incomplete) bins for the current time period.
        /// </summary>
        [DisplayName("partial")]
        public bool Partial { get; set; }
        /// <summary>
        /// Instrument symbol. Send a bare series (e.g. XBU) to get data for the nearest expiring contract in that series.
        /// You can also send a timeframe, e.g.XBU:monthly.Timeframes are daily, weekly, monthly, quarterly, and biquarterly.
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
        public decimal? Count { get; set; }
        /// <summary>
        /// Starting point for results.
        /// </summary>
        [DisplayName("start")]
        public decimal? Start { get; set; }
        /// <summary>
        /// If true, will sort results newest first.
        /// </summary>
        [DisplayName("reverse")]
        public bool Reverse { get; set; }
        /// <summary>
        /// Starting date filter for results.
        /// </summary>
        [DisplayName("startTime")]
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Ending date filter for results.
        /// </summary>
        [DisplayName("endTime")]
        public DateTime? EndTime { get; set; }
    }
    /// <summary>
    /// Update profile
    /// </summary>
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
        /// <summary>
        /// Username can only be set once. To reset, email support.
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }
        /// <summary>
        /// Country of residence.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        /// <summary>
        /// PGP Public Key. If specified, automated emails will be sentwith this key.
        /// </summary>
        [JsonProperty("pgpPubKey")]
        public string PgpPubKey { get; set; }
    }
    /// <summary>
    /// Cancel a withdrawal.
    /// </summary>
    public partial class UserCancelWithdrawalPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Token from your selected TFA type.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    /// <summary>
    /// Check if a referral code is valid
    /// </summary>
    public partial class UserCheckReferralCodeGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Refferal code to check
        /// </summary>
        [DisplayName("referralCode")]
        public string ReferralCode { get; set; }
    }
    /// <summary>
    /// Confirm your email address with a token.
    /// </summary>
    public partial class UserConfirmEmailPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Token from your selected TFA type.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    /// <summary>
    /// Confirm two-factor auth for this account. If using a Yubikey, simply send a token to this endpoint
    /// </summary>
    public partial class UserConfirmEnableTFAPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Two-factor auth type. Supported types: 'GA' (Google Authenticator), 'Yubikey'
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Token from your selected TFA type.
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    /// <summary>
    /// Confirm a withdrawal
    /// </summary>
    public partial class UserConfirmWithdrawalPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Token from your selected TFA type
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    /// <summary>
    /// Get a deposit address
    /// </summary>
    public partial class UserDepositAddressGETRequestParams : QueryStringParams
    {
        /// <summary>
        ///  Currency, e.g. XBt
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
    }
    /// <summary>
    /// Disable two-factor auth for this account.
    /// </summary>
    public partial class UserDisableTFAPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Two-factor auth type. Supported types: 'GA' (Google Authenticator)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Token from your selected TFA type
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }
    }
    /// <summary>
    /// Get your account's margin status. Send a currency of "all" to receive an array of all supported currencies
    /// </summary>
    public partial class UserMarginGETRequestParams : QueryStringParams
    {
        /// <summary>
        ///  Currency, e.g. XBt
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
    }
    /// <summary>
    /// This is changed based on network conditions to ensure timely withdrawals. During network congestion, this may be high. The fee is returned in the same currency.
    /// </summary>
    public partial class UserMinWithdrawalFeeGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Currency, e.g. XBt
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
    }
    /// <summary>
    /// Save user preferences
    /// </summary>
    public partial class UserPreferencesPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("prefs")]
        public string Prefs { get; set; }
        /// <summary>
        /// If true, will overwrite all existing preferences
        /// </summary>
        [JsonProperty("overwrite")]
        public bool Overwrite { get; set; }
    }
    /// <summary>
    /// Use /confirmEnableTFA directly for Yubikeys. This fails if TFA is already enabled
    /// </summary>
    public partial class UserRequestEnableTFAPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// Two-factor auth type. Supported types: 'GA' (Google Authenticator)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
    /// <summary>
    /// This will send a confirmation email to the email address on record, unless requested via an API Key with the withdraw permission
    /// </summary>
    public partial class UserRequestWithdrawalPOSTRequestParams : QueryJsonParams
    {
        /// <summary>
        /// 2FA token. Required if 2FA is enabled on your account.
        /// </summary>
        [JsonProperty("otpToken")]
        public string OtpToken { get; set; }
        /// <summary>
        /// Currency you're withdrawing. Options: XBt
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }
        /// <summary>
        /// Amount of withdrawal currency.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        /// <summary>
        /// Destination Address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// Network fee for Bitcoin withdrawals. If not specified, a default value will be calculated based on Bitcoin network conditions. You will have a chance to confirm this via email.
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }
    }
    /// <summary>
    /// Get your current wallet information
    /// </summary>
    public partial class UserWalletGETRequestParams : QueryStringParams
    {
        /// <summary>
        ///  Currency symbol, e.g. XBt
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
    }
    /// <summary>
    /// Get a history of all of your wallet transactions (deposits, withdrawals, PNL)
    /// </summary>
    public partial class UserWalletHistoryGETRequestParams : QueryStringParams
    {
        /// <summary>
        ///  Currency symbol, e.g. XBt
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
    }
    /// <summary>
    /// Get a summary of all of your wallet transactions (deposits, withdrawals, PNL)
    /// </summary>
    public partial class UserWalletSummaryGETRequestParams : QueryStringParams
    {
        /// <summary>
        /// Currency symbol, e.g. XBt
        /// </summary>
        [DisplayName("currency")]
        public string Currency { get; set; }
    }
}
