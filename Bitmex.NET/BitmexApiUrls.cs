using Bitmex.NET.Dtos;
using Bitmex.NET.Models;
using System.Collections.Generic;

namespace Bitmex.NET
{
	public static partial class BitmexApiUrls
	{
		public static partial class Announcement
		{
			//public static ApiActionAttributes<AnnouncementGETRequestParams, AnnouncementDto> GetAnnouncement = new ApiActionAttributes<AnnouncementGETRequestParams, AnnouncementDto>("announcement", HttpMethods.GET);
			//public static ApiActionAttributes<AnnouncementUrgentGETRequestParams, AnnouncementDto> GetAnnouncementUrgent = new ApiActionAttributes<AnnouncementUrgentGETRequestParams, AnnouncementDto>("announcement/urgent", HttpMethods.GET);
		}
		public static partial class APIKey
		{
			//public static ApiActionAttributes<ApiKeyGETRequestParams, APIKeyDto> GetApiKey = new ApiActionAttributes<ApiKeyGETRequestParams, APIKeyDto>("apiKey", HttpMethods.GET);
			//public static ApiActionAttributes<ApiKeyPOSTRequestParams, APIKeyDto> PostApiKey = new ApiActionAttributes<ApiKeyPOSTRequestParams, APIKeyDto>("apiKey", HttpMethods.POST);
			//public static ApiActionAttributes<ApiKeyDELETERequestParams, APIKeyDto> DeleteApiKey = new ApiActionAttributes<ApiKeyDELETERequestParams, APIKeyDto>("apiKey", HttpMethods.DELETE);
			//public static ApiActionAttributes<ApiKeyDisablePOSTRequestParams, APIKeyDto> PostApiKeyDisable = new ApiActionAttributes<ApiKeyDisablePOSTRequestParams, APIKeyDto>("apiKey/disable", HttpMethods.POST);
			//public static ApiActionAttributes<ApiKeyEnablePOSTRequestParams, APIKeyDto> PostApiKeyEnable = new ApiActionAttributes<ApiKeyEnablePOSTRequestParams, APIKeyDto>("apiKey/enable", HttpMethods.POST);
		}
		public static partial class Chat
		{
			//public static ApiActionAttributes<ChatGETRequestParams, ChatDto> GetChat = new ApiActionAttributes<ChatGETRequestParams, ChatDto>("chat", HttpMethods.GET);
			//public static ApiActionAttributes<ChatPOSTRequestParams, ChatDto> PostChat = new ApiActionAttributes<ChatPOSTRequestParams, ChatDto>("chat", HttpMethods.POST);
			//public static ApiActionAttributes<ChatChannelsGETRequestParams, ChatDto> GetChatChannels = new ApiActionAttributes<ChatChannelsGETRequestParams, ChatDto>("chat/channels", HttpMethods.GET);
			//public static ApiActionAttributes<ChatConnectedGETRequestParams, ChatDto> GetChatConnected = new ApiActionAttributes<ChatConnectedGETRequestParams, ChatDto>("chat/connected", HttpMethods.GET);
		}
		public static partial class Execution
		{
			public static ApiActionAttributes<ExecutionGETRequestParams, List<ExecutionDto>> GetExecution = new ApiActionAttributes<ExecutionGETRequestParams, List<ExecutionDto>>("execution", HttpMethods.GET);
			public static ApiActionAttributes<ExecutionTradeHistoryGETRequestParams, List<ExecutionDto>> GetExecutionTradeHistory = new ApiActionAttributes<ExecutionTradeHistoryGETRequestParams, List<ExecutionDto>>("execution/tradeHistory", HttpMethods.GET);
		}
		public static partial class Funding
		{
			//public static ApiActionAttributes<FundingGETRequestParams, FundingDto> GetFunding = new ApiActionAttributes<FundingGETRequestParams, FundingDto>("funding", HttpMethods.GET);
		}
		public static partial class Instrument
		{
			public static ApiActionAttributes<InstrumentGETRequestParams, List<InstrumentDto>> GetInstrument = new ApiActionAttributes<InstrumentGETRequestParams, List<InstrumentDto>>("instrument", HttpMethods.GET);
			public static ApiActionAttributes<EmptyParameters, List<InstrumentDto>> GetInstrumentActive = new ApiActionAttributes<EmptyParameters, List<InstrumentDto>>("instrument/active", HttpMethods.GET);
			public static ApiActionAttributes<EmptyParameters, List<InstrumentDto>> GetInstrumentActiveAndIndices = new ApiActionAttributes<EmptyParameters, List<InstrumentDto>>("instrument/activeAndIndices", HttpMethods.GET);
			public static ApiActionAttributes<EmptyParameters, InstrumentActiveIntervalsDto> GetInstrumentActiveIntervals = new ApiActionAttributes<EmptyParameters, InstrumentActiveIntervalsDto>("instrument/activeIntervals", HttpMethods.GET);
			public static ApiActionAttributes<InstrumentCompositeIndexGETRequestParams, List<InstrumentCompositeIndexDto>> GetInstrumentCompositeIndex = new ApiActionAttributes<InstrumentCompositeIndexGETRequestParams, List<InstrumentCompositeIndexDto>>("instrument/compositeIndex", HttpMethods.GET);
			public static ApiActionAttributes<EmptyParameters, List<InstrumentDto>> GetInstrumentIndices = new ApiActionAttributes<EmptyParameters, List<InstrumentDto>>("instrument/indices", HttpMethods.GET);
		}
		public static partial class Insurance
		{
			//public static ApiActionAttributes<InsuranceGETRequestParams, InsuranceDto> GetInsurance = new ApiActionAttributes<InsuranceGETRequestParams, InsuranceDto>("insurance", HttpMethods.GET);
		}
		public static partial class Leaderboard
		{
			//public static ApiActionAttributes<LeaderboardGETRequestParams, LeaderboardDto> GetLeaderboard = new ApiActionAttributes<LeaderboardGETRequestParams, LeaderboardDto>("leaderboard", HttpMethods.GET);
			//public static ApiActionAttributes<LeaderboardNameGETRequestParams, LeaderboardDto> GetLeaderboardName = new ApiActionAttributes<LeaderboardNameGETRequestParams, LeaderboardDto>("leaderboard/name", HttpMethods.GET);
		}
		public static partial class Liquidation
		{
			//public static ApiActionAttributes<LiquidationGETRequestParams, LiquidationDto> GetLiquidation = new ApiActionAttributes<LiquidationGETRequestParams, LiquidationDto>("liquidation", HttpMethods.GET);
		}
		public static partial class Notification
		{
			//public static ApiActionAttributes<NotificationGETRequestParams, NotificationDto> GetNotification = new ApiActionAttributes<NotificationGETRequestParams, NotificationDto>("notification", HttpMethods.GET);
		}
		public static partial class Order
		{
			public static ApiActionAttributes<OrderGETRequestParams, List<OrderDto>> GetOrder = new ApiActionAttributes<OrderGETRequestParams, List<OrderDto>>("order", HttpMethods.GET);
			public static ApiActionAttributes<OrderPUTRequestParams, OrderDto> PutOrder = new ApiActionAttributes<OrderPUTRequestParams, OrderDto>("order", HttpMethods.PUT);
			public static ApiActionAttributes<OrderPOSTRequestParams, OrderDto> PostOrder = new ApiActionAttributes<OrderPOSTRequestParams, OrderDto>("order", HttpMethods.POST);
			public static ApiActionAttributes<OrderDELETERequestParams, List<OrderDto>> DeleteOrder = new ApiActionAttributes<OrderDELETERequestParams, List<OrderDto>>("order", HttpMethods.DELETE);
			public static ApiActionAttributes<OrderAllDELETERequestParams, List<OrderDto>> DeleteOrderAll = new ApiActionAttributes<OrderAllDELETERequestParams, List<OrderDto>>("order/all", HttpMethods.DELETE);
			public static ApiActionAttributes<OrderBulkPUTRequestParams, List<OrderDto>> PutOrderBulk = new ApiActionAttributes<OrderBulkPUTRequestParams, List<OrderDto>>("order/bulk", HttpMethods.PUT);
			public static ApiActionAttributes<OrderBulkPOSTRequestParams, List<OrderDto>> PostOrderBulk = new ApiActionAttributes<OrderBulkPOSTRequestParams, List<OrderDto>>("order/bulk", HttpMethods.POST);
			public static ApiActionAttributes<OrderCancelAllAfterPOSTRequestParams, object> PostOrderCancelAllAfter = new ApiActionAttributes<OrderCancelAllAfterPOSTRequestParams, object>("order/cancelAllAfter", HttpMethods.POST);
			public static ApiActionAttributes<OrderClosePositionPOSTRequestParams, OrderDto> PostOrderClosePosition = new ApiActionAttributes<OrderClosePositionPOSTRequestParams, OrderDto>("order/closePosition", HttpMethods.POST);
		}
		public static partial class OrderBook
		{
			public static ApiActionAttributes<OrderBookL2GETRequestParams, List<OrderBookDto>> GetOrderBookL2 = new ApiActionAttributes<OrderBookL2GETRequestParams, List<OrderBookDto>>("orderBook/L2", HttpMethods.GET);
		}
		public static partial class Position
		{
			public static ApiActionAttributes<PositionGETRequestParams, List<PositionDto>> GetPosition = new ApiActionAttributes<PositionGETRequestParams, List<PositionDto>>("position", HttpMethods.GET);
			public static ApiActionAttributes<PositionIsolatePOSTRequestParams, PositionDto> PostPositionIsolate = new ApiActionAttributes<PositionIsolatePOSTRequestParams, PositionDto>("position/isolate", HttpMethods.POST);
			public static ApiActionAttributes<PositionLeveragePOSTRequestParams, PositionDto> PostPositionLeverage = new ApiActionAttributes<PositionLeveragePOSTRequestParams, PositionDto>("position/leverage", HttpMethods.POST);
			public static ApiActionAttributes<PositionRiskLimitPOSTRequestParams, PositionDto> PostPositionRiskLimit = new ApiActionAttributes<PositionRiskLimitPOSTRequestParams, PositionDto>("position/riskLimit", HttpMethods.POST);
			public static ApiActionAttributes<PositionTransferMarginPOSTRequestParams, PositionDto> PostPositionTransferMargin = new ApiActionAttributes<PositionTransferMarginPOSTRequestParams, PositionDto>("position/transferMargin", HttpMethods.POST);
		}
		public static partial class Quote
		{
			public static ApiActionAttributes<QuoteGETRequestParams, List<QuoteDto>> GetQuote = new ApiActionAttributes<QuoteGETRequestParams, List<QuoteDto>>("quote", HttpMethods.GET);
			public static ApiActionAttributes<QuoteBucketedGETRequestParams, List<QuoteDto>> GetQuoteBucketed = new ApiActionAttributes<QuoteBucketedGETRequestParams, List<QuoteDto>>("quote/bucketed", HttpMethods.GET);
		}
		public static partial class Schema
		{
			//public static ApiActionAttributes<SchemaGETRequestParams, SchemaDto> GetSchema = new ApiActionAttributes<SchemaGETRequestParams, SchemaDto>("schema", HttpMethods.GET);
			//public static ApiActionAttributes<SchemaWebsocketHelpGETRequestParams, SchemaDto> GetSchemaWebsocketHelp = new ApiActionAttributes<SchemaWebsocketHelpGETRequestParams, SchemaDto>("schema/websocketHelp", HttpMethods.GET);
		}
		public static partial class Settlement
		{
			//public static ApiActionAttributes<SettlementGETRequestParams, SettlementDto> GetSettlement = new ApiActionAttributes<SettlementGETRequestParams, SettlementDto>("settlement", HttpMethods.GET);
		}
		public static partial class Stats
		{
			//public static ApiActionAttributes<StatsGETRequestParams, StatsDto> GetStats = new ApiActionAttributes<StatsGETRequestParams, StatsDto>("stats", HttpMethods.GET);
			//public static ApiActionAttributes<StatsHistoryGETRequestParams, StatsDto> GetStatsHistory = new ApiActionAttributes<StatsHistoryGETRequestParams, StatsDto>("stats/history", HttpMethods.GET);
			//public static ApiActionAttributes<StatsHistoryUSDGETRequestParams, StatsDto> GetStatsHistoryUSD = new ApiActionAttributes<StatsHistoryUSDGETRequestParams, StatsDto>("stats/historyUSD", HttpMethods.GET);
		}
		public static partial class Trade
		{
			public static ApiActionAttributes<TradeGETRequestParams, List<TradeDto>> GetTrade = new ApiActionAttributes<TradeGETRequestParams, List<TradeDto>>("trade", HttpMethods.GET);
			public static ApiActionAttributes<TradeBucketedGETRequestParams, List<TradeBucketedDto>> GetTradeBucketed = new ApiActionAttributes<TradeBucketedGETRequestParams, List<TradeBucketedDto>>("trade/bucketed", HttpMethods.GET);
		}
		public static partial class User
		{
			//public static ApiActionAttributes<UserGETRequestParams, UserDto> GetUser = new ApiActionAttributes<UserGETRequestParams, UserDto>("user", HttpMethods.GET);
			//public static ApiActionAttributes<UserPUTRequestParams, UserDto> PutUser = new ApiActionAttributes<UserPUTRequestParams, UserDto>("user", HttpMethods.PUT);
			//public static ApiActionAttributes<UserAffiliateStatusGETRequestParams, UserDto> GetUserAffiliateStatus = new ApiActionAttributes<UserAffiliateStatusGETRequestParams, UserDto>("user/affiliateStatus", HttpMethods.GET);
			//public static ApiActionAttributes<UserCancelWithdrawalPOSTRequestParams, UserDto> PostUserCancelWithdrawal = new ApiActionAttributes<UserCancelWithdrawalPOSTRequestParams, UserDto>("user/cancelWithdrawal", HttpMethods.POST);
			//public static ApiActionAttributes<UserCheckReferralCodeGETRequestParams, UserDto> GetUserCheckReferralCode = new ApiActionAttributes<UserCheckReferralCodeGETRequestParams, UserDto>("user/checkReferralCode", HttpMethods.GET);
			//public static ApiActionAttributes<UserCommissionGETRequestParams, UserDto> GetUserCommission = new ApiActionAttributes<UserCommissionGETRequestParams, UserDto>("user/commission", HttpMethods.GET);
			//public static ApiActionAttributes<UserConfirmEmailPOSTRequestParams, UserDto> PostUserConfirmEmail = new ApiActionAttributes<UserConfirmEmailPOSTRequestParams, UserDto>("user/confirmEmail", HttpMethods.POST);
			//public static ApiActionAttributes<UserConfirmEnableTFAPOSTRequestParams, UserDto> PostUserConfirmEnableTFA = new ApiActionAttributes<UserConfirmEnableTFAPOSTRequestParams, UserDto>("user/confirmEnableTFA", HttpMethods.POST);
			//public static ApiActionAttributes<UserConfirmWithdrawalPOSTRequestParams, UserDto> PostUserConfirmWithdrawal = new ApiActionAttributes<UserConfirmWithdrawalPOSTRequestParams, UserDto>("user/confirmWithdrawal", HttpMethods.POST);
			//public static ApiActionAttributes<UserDepositAddressGETRequestParams, UserDto> GetUserDepositAddress = new ApiActionAttributes<UserDepositAddressGETRequestParams, UserDto>("user/depositAddress", HttpMethods.GET);
			//public static ApiActionAttributes<UserDisableTFAPOSTRequestParams, UserDto> PostUserDisableTFA = new ApiActionAttributes<UserDisableTFAPOSTRequestParams, UserDto>("user/disableTFA", HttpMethods.POST);
			//public static ApiActionAttributes<UserLogoutPOSTRequestParams, UserDto> PostUserLogout = new ApiActionAttributes<UserLogoutPOSTRequestParams, UserDto>("user/logout", HttpMethods.POST);
			//public static ApiActionAttributes<UserLogoutAllPOSTRequestParams, UserDto> PostUserLogoutAll = new ApiActionAttributes<UserLogoutAllPOSTRequestParams, UserDto>("user/logoutAll", HttpMethods.POST);
			//public static ApiActionAttributes<UserMarginGETRequestParams, UserDto> GetUserMargin = new ApiActionAttributes<UserMarginGETRequestParams, UserDto>("user/margin", HttpMethods.GET);
			//public static ApiActionAttributes<UserMinWithdrawalFeeGETRequestParams, UserDto> GetUserMinWithdrawalFee = new ApiActionAttributes<UserMinWithdrawalFeeGETRequestParams, UserDto>("user/minWithdrawalFee", HttpMethods.GET);
			//public static ApiActionAttributes<UserPreferencesPOSTRequestParams, UserDto> PostUserPreferences = new ApiActionAttributes<UserPreferencesPOSTRequestParams, UserDto>("user/preferences", HttpMethods.POST);
			//public static ApiActionAttributes<UserRequestEnableTFAPOSTRequestParams, UserDto> PostUserRequestEnableTFA = new ApiActionAttributes<UserRequestEnableTFAPOSTRequestParams, UserDto>("user/requestEnableTFA", HttpMethods.POST);
			//public static ApiActionAttributes<UserRequestWithdrawalPOSTRequestParams, UserDto> PostUserRequestWithdrawal = new ApiActionAttributes<UserRequestWithdrawalPOSTRequestParams, UserDto>("user/requestWithdrawal", HttpMethods.POST);
			//public static ApiActionAttributes<UserWalletGETRequestParams, UserDto> GetUserWallet = new ApiActionAttributes<UserWalletGETRequestParams, UserDto>("user/wallet", HttpMethods.GET);
			//public static ApiActionAttributes<UserWalletHistoryGETRequestParams, UserDto> GetUserWalletHistory = new ApiActionAttributes<UserWalletHistoryGETRequestParams, UserDto>("user/walletHistory", HttpMethods.GET);
			//public static ApiActionAttributes<UserWalletSummaryGETRequestParams, UserDto> GetUserWalletSummary = new ApiActionAttributes<UserWalletSummaryGETRequestParams, UserDto>("user/walletSummary", HttpMethods.GET);
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
