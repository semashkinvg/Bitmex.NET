using Bitmex.NET.Dtos;
using Bitmex.NET.Models;
using System;
using System.Collections.Generic;

namespace Bitmex.NET
{
    public static partial class BitmexApiUrls
    {
        /// <summary>
        /// Public Announcements
        /// </summary>
        public static partial class Announcement
        {
            /// <summary>
            /// Get site announcements
            /// </summary>
            public static ApiActionAttributes<AnnouncementGETRequestParams, List<AnnouncementDto>> GetAnnouncement = new ApiActionAttributes<AnnouncementGETRequestParams, List<AnnouncementDto>>("announcement", HttpMethods.GET);
            /// <summary>
            /// Get urgent (banner) announcements
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<AnnouncementDto>> GetAnnouncementUrgent = new ApiActionAttributes<EmptyParameters, List<AnnouncementDto>>("announcement/urgent", HttpMethods.GET);
        }
        /// <summary>
        /// Persistent API Keys for Developers
        /// </summary>
        public static partial class APIKey
        {
            /// <summary>
            /// Get your API Keys
            /// </summary>
            public static ApiActionAttributes<ApiKeyGETRequestParams, List<APIKeyDto>> GetApiKey = new ApiActionAttributes<ApiKeyGETRequestParams, List<APIKeyDto>>("apiKey", HttpMethods.GET);
            /// <summary>
            /// Create an API key. Note: API Keys can only be created via the frontend.
            /// </summary>
            public static ApiActionAttributes<ApiKeyPOSTRequestParams, APIKeyDto> PostApiKey = new ApiActionAttributes<ApiKeyPOSTRequestParams, APIKeyDto>("apiKey", HttpMethods.POST);
            /// <summary>
            /// Delete an API key
            /// </summary>
            public static ApiActionAttributes<ApiKeyDELETERequestParams, APIKeyDeleteDto> DeleteApiKey = new ApiActionAttributes<ApiKeyDELETERequestParams, APIKeyDeleteDto>("apiKey", HttpMethods.DELETE);
            /// <summary>
            /// Disable an API key
            /// </summary>
            public static ApiActionAttributes<ApiKeyDisablePOSTRequestParams, APIKeyDto> PostApiKeyDisable = new ApiActionAttributes<ApiKeyDisablePOSTRequestParams, APIKeyDto>("apiKey/disable", HttpMethods.POST);
            /// <summary>
            /// Enable an API key
            /// </summary>
            public static ApiActionAttributes<ApiKeyEnablePOSTRequestParams, APIKeyDto> PostApiKeyEnable = new ApiActionAttributes<ApiKeyEnablePOSTRequestParams, APIKeyDto>("apiKey/enable", HttpMethods.POST);
        }
        /// <summary>
        /// Trollbox Data
        /// </summary>
        public static partial class Chat
        {
            public static ApiActionAttributes<ChatGETRequestParams, List<ChatDto>> GetChat = new ApiActionAttributes<ChatGETRequestParams, List<ChatDto>>("chat", HttpMethods.GET);
            public static ApiActionAttributes<ChatPOSTRequestParams, ChatDto> PostChat = new ApiActionAttributes<ChatPOSTRequestParams, ChatDto>("chat", HttpMethods.POST);
            public static ApiActionAttributes<EmptyParameters, List<ChatChannelDto>> GetChatChannels = new ApiActionAttributes<EmptyParameters, List<ChatChannelDto>>("chat/channels", HttpMethods.GET);
            public static ApiActionAttributes<EmptyParameters, ChatConnectedDto> GetChatConnected = new ApiActionAttributes<EmptyParameters, ChatConnectedDto>("chat/connected", HttpMethods.GET);
        }
        /// <summary>
        /// Raw Order and Balance Data
        /// </summary>
        public static partial class Execution
        {
            /// <summary>
            /// Get all raw executions for your account.
            /// </summary>
            public static ApiActionAttributes<ExecutionGETRequestParams, List<ExecutionDto>> GetExecution = new ApiActionAttributes<ExecutionGETRequestParams, List<ExecutionDto>>("execution", HttpMethods.GET);
            /// <summary>
            /// Get all balance-affecting executions. This includes each trade, insurance charge, and settlement
            /// </summary>
            public static ApiActionAttributes<ExecutionTradeHistoryGETRequestParams, List<ExecutionDto>> GetExecutionTradeHistory = new ApiActionAttributes<ExecutionTradeHistoryGETRequestParams, List<ExecutionDto>>("execution/tradeHistory", HttpMethods.GET);
        }
        /// <summary>
        /// Swap Funding History
        /// </summary>
        public static partial class Funding
        {
            /// <summary>
            /// Get funding history
            /// </summary>
            public static ApiActionAttributes<FundingGETRequestParams, List<FundingDto>> GetFunding = new ApiActionAttributes<FundingGETRequestParams, List<FundingDto>>("funding", HttpMethods.GET);
        }
        /// <summary>
        /// Tradeable Contracts, Indices, and History
        /// </summary>
        public static partial class Instrument
        {
            /// <summary>
            /// Get instruments
            /// </summary>
            public static ApiActionAttributes<InstrumentGETRequestParams, List<InstrumentDto>> GetInstrument = new ApiActionAttributes<InstrumentGETRequestParams, List<InstrumentDto>>("instrument", HttpMethods.GET);
            /// <summary>
            /// Get all active instruments and instruments that have expired in less than 24hrs
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<InstrumentDto>> GetInstrumentActive = new ApiActionAttributes<EmptyParameters, List<InstrumentDto>>("instrument/active", HttpMethods.GET);
            /// <summary>
            /// Helper method. Gets all active instruments and all indices. This is a join of the result of /indices and /active
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<InstrumentDto>> GetInstrumentActiveAndIndices = new ApiActionAttributes<EmptyParameters, List<InstrumentDto>>("instrument/activeAndIndices", HttpMethods.GET);
            /// <summary>
            /// Return all active contract series and interval pairs
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, InstrumentActiveIntervalsDto> GetInstrumentActiveIntervals = new ApiActionAttributes<EmptyParameters, InstrumentActiveIntervalsDto>("instrument/activeIntervals", HttpMethods.GET);
            /// <summary>
            /// Show constituent parts of an index
            /// </summary>
            public static ApiActionAttributes<InstrumentCompositeIndexGETRequestParams, List<InstrumentCompositeIndexDto>> GetInstrumentCompositeIndex = new ApiActionAttributes<InstrumentCompositeIndexGETRequestParams, List<InstrumentCompositeIndexDto>>("instrument/compositeIndex", HttpMethods.GET);
            /// <summary>
            /// Get all price indices
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<InstrumentDto>> GetInstrumentIndices = new ApiActionAttributes<EmptyParameters, List<InstrumentDto>>("instrument/indices", HttpMethods.GET);
        }
        /// <summary>
        /// Insurance Fund Data
        /// </summary>
        public static partial class Insurance
        {
            /// <summary>
            /// Get insurance fund history
            /// </summary>
            public static ApiActionAttributes<InsuranceGETRequestParams, List<InsuranceDto>> GetInsurance = new ApiActionAttributes<InsuranceGETRequestParams, List<InsuranceDto>>("insurance", HttpMethods.GET);
        }
        /// <summary>
        /// Information on Top Users
        /// </summary>
        public static partial class Leaderboard
        {
            /// <summary>
            /// Get current leaderboard. Allowed methods: 'notional', 'ROE'
            /// </summary>
            public static ApiActionAttributes<LeaderboardGETRequestParams, List<LeaderboardDto>> GetLeaderboard = new ApiActionAttributes<LeaderboardGETRequestParams, List<LeaderboardDto>>("leaderboard", HttpMethods.GET);
            /// <summary>
            /// Get your alias on the leaderboard.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, LeaderboardNameDto> GetLeaderboardName = new ApiActionAttributes<EmptyParameters, LeaderboardNameDto>("leaderboard/name", HttpMethods.GET);
        }
        /// <summary>
        /// Active Liquidations
        /// </summary>
        public static partial class Liquidation
        {
            public static ApiActionAttributes<LiquidationGETRequestParams, List<LiquidationDto>> GetLiquidation = new ApiActionAttributes<LiquidationGETRequestParams, List<LiquidationDto>>("liquidation", HttpMethods.GET);
        }
        /// <summary>
        /// Account Notifications
        /// </summary>
        public static partial class Notification
        {
            /// <summary>
            /// This is an upcoming feature and currently does not return data.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<NotificationDto>> GetNotification = new ApiActionAttributes<EmptyParameters, List<NotificationDto>>("notification", HttpMethods.GET);
        }
        /// <summary>
        /// Placement, Cancellation, Amending, and History
        /// </summary>
        public static partial class Order
        {
            /// <summary>
            /// Get your orders
            /// </summary>
            public static ApiActionAttributes<OrderGETRequestParams, List<OrderDto>> GetOrder = new ApiActionAttributes<OrderGETRequestParams, List<OrderDto>>("order", HttpMethods.GET);
            /// <summary>
            /// Amend the quantity or price of an open order
            /// </summary>
            public static ApiActionAttributes<OrderPUTRequestParams, OrderDto> PutOrder = new ApiActionAttributes<OrderPUTRequestParams, OrderDto>("order", HttpMethods.PUT);
            /// <summary>
            /// Create a new order
            /// </summary>
            public static ApiActionAttributes<OrderPOSTRequestParams, OrderDto> PostOrder = new ApiActionAttributes<OrderPOSTRequestParams, OrderDto>("order", HttpMethods.POST);
            /// <summary>
            /// Cancel order(s). Send multiple order IDs to cancel in bulk
            /// </summary>
            public static ApiActionAttributes<OrderDELETERequestParams, List<OrderDto>> DeleteOrder = new ApiActionAttributes<OrderDELETERequestParams, List<OrderDto>>("order", HttpMethods.DELETE);
            /// <summary>
            /// Cancels all of your orders.
            /// </summary>
            public static ApiActionAttributes<OrderAllDELETERequestParams, List<OrderDto>> DeleteOrderAll = new ApiActionAttributes<OrderAllDELETERequestParams, List<OrderDto>>("order/all", HttpMethods.DELETE);
            /// <summary>
            /// Amend multiple orders for the same symbol
            /// </summary>
            public static ApiActionAttributes<OrderBulkPUTRequestParams, List<OrderDto>> PutOrderBulk = new ApiActionAttributes<OrderBulkPUTRequestParams, List<OrderDto>>("order/bulk", HttpMethods.PUT);
            /// <summary>
            /// Create multiple new orders for the same symbol
            /// </summary>
            public static ApiActionAttributes<OrderBulkPOSTRequestParams, List<OrderDto>> PostOrderBulk = new ApiActionAttributes<OrderBulkPOSTRequestParams, List<OrderDto>>("order/bulk", HttpMethods.POST);
            /// <summary>
            /// Automatically cancel all your orders after a specified timeout
            /// </summary>
            public static ApiActionAttributes<OrderCancelAllAfterPOSTRequestParams, object> PostOrderCancelAllAfter = new ApiActionAttributes<OrderCancelAllAfterPOSTRequestParams, object>("order/cancelAllAfter", HttpMethods.POST);
            /// <summary>
            /// Close a position. [Deprecated, use POST /order with execInst: 'Close']
            /// </summary>
            [Obsolete]
            public static ApiActionAttributes<OrderClosePositionPOSTRequestParams, OrderDto> PostOrderClosePosition = new ApiActionAttributes<OrderClosePositionPOSTRequestParams, OrderDto>("order/closePosition", HttpMethods.POST);
        }
        /// <summary>
        /// Level 2 Book Data
        /// </summary>
        public static partial class OrderBook
        {
            /// <summary>
            /// Get current orderbook in vertical format
            /// </summary>
            public static ApiActionAttributes<OrderBookL2GETRequestParams, List<OrderBookDto>> GetOrderBookL2 = new ApiActionAttributes<OrderBookL2GETRequestParams, List<OrderBookDto>>("orderBook/L2", HttpMethods.GET);
        }
        /// <summary>
        /// Summary of Open and Closed Positions
        /// </summary>
        public static partial class Position
        {
            /// <summary>
            /// Get your positions
            /// </summary>
            public static ApiActionAttributes<PositionGETRequestParams, List<PositionDto>> GetPosition = new ApiActionAttributes<PositionGETRequestParams, List<PositionDto>>("position", HttpMethods.GET);
            /// <summary>
            /// Enable isolated margin or cross margin per-position
            /// </summary>
            public static ApiActionAttributes<PositionIsolatePOSTRequestParams, PositionDto> PostPositionIsolate = new ApiActionAttributes<PositionIsolatePOSTRequestParams, PositionDto>("position/isolate", HttpMethods.POST);
            /// <summary>
            /// Choose leverage for a position
            /// </summary>
            public static ApiActionAttributes<PositionLeveragePOSTRequestParams, PositionDto> PostPositionLeverage = new ApiActionAttributes<PositionLeveragePOSTRequestParams, PositionDto>("position/leverage", HttpMethods.POST);
            /// <summary>
            /// Update your risk limit
            /// </summary>
            public static ApiActionAttributes<PositionRiskLimitPOSTRequestParams, PositionDto> PostPositionRiskLimit = new ApiActionAttributes<PositionRiskLimitPOSTRequestParams, PositionDto>("position/riskLimit", HttpMethods.POST);
            /// <summary>
            /// Transfer equity in or out of a position
            /// </summary>
            public static ApiActionAttributes<PositionTransferMarginPOSTRequestParams, PositionDto> PostPositionTransferMargin = new ApiActionAttributes<PositionTransferMarginPOSTRequestParams, PositionDto>("position/transferMargin", HttpMethods.POST);
        }
        /// <summary>
        /// Best Bid/Offer Snapshots & Historical Bins
        /// </summary>
        public static partial class Quote
        {
            /// <summary>
            /// Get Quotes
            /// </summary>
            public static ApiActionAttributes<QuoteGETRequestParams, List<QuoteDto>> GetQuote = new ApiActionAttributes<QuoteGETRequestParams, List<QuoteDto>>("quote", HttpMethods.GET);
            /// <summary>
            /// Get previous quotes in time buckets
            /// </summary>
            public static ApiActionAttributes<QuoteBucketedGETRequestParams, List<QuoteDto>> GetQuoteBucketed = new ApiActionAttributes<QuoteBucketedGETRequestParams, List<QuoteDto>>("quote/bucketed", HttpMethods.GET);
        }
        /// <summary>
        /// Dynamic Schemata for Developers
        /// </summary>
        public static partial class Schema
        {
            public static ApiActionAttributes<SchemaGETRequestParams, Dictionary<string, SchemaDto>> GetSchema = new ApiActionAttributes<SchemaGETRequestParams, Dictionary<string, SchemaDto>>("schema", HttpMethods.GET);
            public static ApiActionAttributes<EmptyParameters, SchemaWebSocketHelpDto> GetSchemaWebsocketHelp = new ApiActionAttributes<EmptyParameters, SchemaWebSocketHelpDto>("schema/websocketHelp", HttpMethods.GET);
        }
        /// <summary>
        /// Historical Settlement Data
        /// </summary>
        public static partial class Settlement
        {
            public static ApiActionAttributes<SettlementGETRequestParams, List<SettlementDto>> GetSettlement = new ApiActionAttributes<SettlementGETRequestParams, List<SettlementDto>>("settlement", HttpMethods.GET);
        }
        /// <summary>
        /// Exchange Statistics
        /// </summary>
        public static partial class Stats
        {
            /// <summary>
            /// Get exchange-wide and per-series turnover and volume statistics
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<StatsDto>> GetStats = new ApiActionAttributes<EmptyParameters, List<StatsDto>>("stats", HttpMethods.GET);
            /// <summary>
            /// Get historical exchange-wide and per-series turnover and volume statistics
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<StatsHistoryDto>> GetStatsHistory = new ApiActionAttributes<EmptyParameters, List<StatsHistoryDto>>("stats/history", HttpMethods.GET);
            /// <summary>
            /// Get a summary of exchange statistics in USD
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, List<StatsHistoryDto>> GetStatsHistoryUsd = new ApiActionAttributes<EmptyParameters, List<StatsHistoryDto>>("stats/historyUSD", HttpMethods.GET);
        }
        /// <summary>
        /// Individual & Bucketed Trades
        /// </summary>
        public static partial class Trade
        {
            /// <summary>
            /// Get Trades
            /// </summary>
            public static ApiActionAttributes<TradeGETRequestParams, List<TradeDto>> GetTrade = new ApiActionAttributes<TradeGETRequestParams, List<TradeDto>>("trade", HttpMethods.GET);
            /// <summary>
            /// Get previous trades in time buckets
            /// </summary>
            public static ApiActionAttributes<TradeBucketedGETRequestParams, List<TradeBucketedDto>> GetTradeBucketed = new ApiActionAttributes<TradeBucketedGETRequestParams, List<TradeBucketedDto>>("trade/bucketed", HttpMethods.GET);
        }

        /// <summary>
        /// User API
        /// </summary>
        public static partial class User
        {
            /// <summary>
            /// Returns general user info.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, UserDto> GetUser = new ApiActionAttributes<EmptyParameters, UserDto>("user", HttpMethods.GET);

            /// <summary>
            /// Updates user account information.
            /// </summary>
            public static ApiActionAttributes<UserPUTRequestParams, UserDto> PutUser = new ApiActionAttributes<UserPUTRequestParams, UserDto>("user", HttpMethods.PUT);

            /// <summary>
            /// Returns your current affiliate/referral status.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, AffiliateDto> GetUserAffiliateStatus = new ApiActionAttributes<EmptyParameters, AffiliateDto>("user/affiliateStatus", HttpMethods.GET);

            /// <summary>
            /// Cancels a withdrawal.
            /// </summary>
            public static ApiActionAttributes<UserCancelWithdrawalPOSTRequestParams, double?> PostUserCancelWithdrawal = new ApiActionAttributes<UserCancelWithdrawalPOSTRequestParams, double?>("user/cancelWithdrawal", HttpMethods.POST);

            /// <summary>
            /// Checks if a referral code is valid.
            /// </summary>
            public static ApiActionAttributes<UserCheckReferralCodeGETRequestParams, double?> GetUserCheckReferralCode = new ApiActionAttributes<UserCheckReferralCodeGETRequestParams, double?>("user/checkReferralCode", HttpMethods.GET);

            /// <summary>
            /// Gets your account's commission status.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, Dictionary<string, UserCommissionDto>> GetUserCommission = new ApiActionAttributes<EmptyParameters, Dictionary<string, UserCommissionDto>>("user/commission", HttpMethods.GET);

            /// <summary>
            /// Confirms your email address with a token.
            /// </summary>
            public static ApiActionAttributes<UserConfirmEmailPOSTRequestParams, AccessTokenDto> PostUserConfirmEmail = new ApiActionAttributes<UserConfirmEmailPOSTRequestParams, AccessTokenDto>("user/confirmEmail", HttpMethods.POST);

            /// <summary>
            /// Confirms two-factor auth for this account. If using a Yubikey, simply send a token to this endpoint.
            /// </summary>
            public static ApiActionAttributes<UserConfirmEnableTFAPOSTRequestParams, bool?> PostUserConfirmEnableTfa = new ApiActionAttributes<UserConfirmEnableTFAPOSTRequestParams, bool?>("user/confirmEnableTFA", HttpMethods.POST);

            /// <summary>
            /// Confirms a withdrawal.
            /// </summary>
            public static ApiActionAttributes<UserConfirmWithdrawalPOSTRequestParams, TransactionDto> PostUserConfirmWithdrawal = new ApiActionAttributes<UserConfirmWithdrawalPOSTRequestParams, TransactionDto>("user/confirmWithdrawal", HttpMethods.POST);

            /// <summary>
            /// Gets a deposit address.
            /// </summary>
            public static ApiActionAttributes<UserDepositAddressGETRequestParams, string> GetUserDepositAddress = new ApiActionAttributes<UserDepositAddressGETRequestParams, string>("user/depositAddress", HttpMethods.GET);

            /// <summary>
            /// Disables two-factor auth for this account.
            /// </summary>
            public static ApiActionAttributes<UserDisableTFAPOSTRequestParams, bool?> PostUserDisableTfa = new ApiActionAttributes<UserDisableTFAPOSTRequestParams, bool?>("user/disableTFA", HttpMethods.POST);

            /// <summary>
            /// Logs out of BitMEX.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, object> PostUserLogout = new ApiActionAttributes<EmptyParameters, object>("user/logout", HttpMethods.POST);

            /// <summary>
            /// Logs all systems out of BitMEX. This will revoke all of your account's access tokens, logging you out on all devices.
            /// </summary>
            public static ApiActionAttributes<EmptyParameters, double?> PostUserLogoutAll = new ApiActionAttributes<EmptyParameters, double?>("user/logoutAll", HttpMethods.POST);

            /// <summary>
            /// Get your account's margin status. Send a currency of "all" to receive an array of all supported currencies.
            /// </summary>
            public static ApiActionAttributes<UserMarginGETRequestParams, MarginDto> GetUserMargin = new ApiActionAttributes<UserMarginGETRequestParams, MarginDto>("user/margin", HttpMethods.GET);

            /// <summary>
            /// Gets the minimum withdrawal fee for a currency.
            /// </summary>
            public static ApiActionAttributes<UserMinWithdrawalFeeGETRequestParams, MinWithdrawalFeeDto> GetUserMinWithdrawalFee = new ApiActionAttributes<UserMinWithdrawalFeeGETRequestParams, MinWithdrawalFeeDto>("user/minWithdrawalFee", HttpMethods.GET);

            /// <summary>
            /// Saves user preferences.
            /// </summary>
            public static ApiActionAttributes<UserPreferencesPOSTRequestParams, UserDto> PostUserPreferences = new ApiActionAttributes<UserPreferencesPOSTRequestParams, UserDto>("user/preferences", HttpMethods.POST);

            /// <summary>
            /// Get secret key for setting up two-factor auth.
            /// </summary>
            public static ApiActionAttributes<UserRequestEnableTFAPOSTRequestParams, bool?> PostUserRequestEnableTFA = new ApiActionAttributes<UserRequestEnableTFAPOSTRequestParams, bool?>("user/requestEnableTFA", HttpMethods.POST);

            /// <summary>
            /// Requests a withdrawal to an external wallet.
            /// </summary>
            public static ApiActionAttributes<UserRequestWithdrawalPOSTRequestParams, TransactionDto> PostUserRequestWithdrawal = new ApiActionAttributes<UserRequestWithdrawalPOSTRequestParams, TransactionDto>("user/requestWithdrawal", HttpMethods.POST);

            /// <summary>
            /// Gets your current wallet information.
            /// </summary>
            public static ApiActionAttributes<UserWalletGETRequestParams, WalletDto> GetUserWallet = new ApiActionAttributes<UserWalletGETRequestParams, WalletDto>("user/wallet", HttpMethods.GET);

            /// <summary>
            /// Gets a history of all of your wallet transactions (deposits, withdrawals, PNL).
            /// </summary>
            public static ApiActionAttributes<UserWalletHistoryGETRequestParams, List<WalletHistoryDbo>> GetUserWalletHistory = new ApiActionAttributes<UserWalletHistoryGETRequestParams, List<WalletHistoryDbo>>("user/walletHistory", HttpMethods.GET);

            /// <summary>
            /// Gets a summary of all of your wallet transactions (deposits, withdrawals, PNL).
            /// </summary>
            public static ApiActionAttributes<UserWalletSummaryGETRequestParams, List<TransactionDto>> GetUserWalletSummary = new ApiActionAttributes<UserWalletSummaryGETRequestParams, List<TransactionDto>>("user/walletSummary", HttpMethods.GET);
        }
    }

    public class ApiActionAttributes<TParams, TResult>
    {
        public string Action { get; }
        public HttpMethods Method { get; }

        public ApiActionAttributes(string action, HttpMethods method)
        {
            Action = action;
            Method = method;
        }

    }
}
