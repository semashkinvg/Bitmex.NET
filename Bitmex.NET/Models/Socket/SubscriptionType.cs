namespace Bitmex.NET.Models.Socket
{
	public enum SubscriptionType
	{
		announcement, // Site announcements
		chat, // Trollbox chat
		connected, // Statistics of connected users/bots
		funding, // Updates of swap funding rates. Sent every funding interval (usually 8hrs)
		instrument, // Instrument updates including turnover and bid/ask
		insurance, // Daily Insurance Fund updates
		liquidation, // Liquidation orders as they're entered into the book
		orderBookL2, // Full level 2 orderBook
		orderBook10, // Top 10 levels using traditional full book push
		publicNotifications, // System-wide notifications (used for short-lived messages)
		quote, // Top level of the book
		quoteBin1m, // 1-minute quote bins
		quoteBin5m, // 5-minute quote bins
		quoteBin1h, // 1-hour quote bins
		quoteBin1d, // 1-day quote bins
		settlement, // Settlements
		trade, // Live trades
		tradeBin1m, // 1-minute trade bins
		tradeBin5m, // 5-minute trade bins
		tradeBin1h, // 1-hour trade bins
		tradeBin1d, // 1-day trade bins

		affiliate, // Affiliate status, such as total referred users & payout %
		execution, // Individual executions; can be multiple per order
		order, // Live updates on your orders
		margin, // Updates on your current account balance and margin requirements
		position, // Updates on your positions
		privateNotifications, // Individual notifications - currently not used
		transact, // Deposit/Withdrawal updates
		wallet // Bitcoin address balance data, including total deposits & withdrawals
	}
}
