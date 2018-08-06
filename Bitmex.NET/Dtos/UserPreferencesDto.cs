using System;
using System.Collections.Generic;

namespace Bitmex.NET.Dtos
{
    public class UserPreferencesDto
    {
        public bool? AlertOnLiquidations { get; set; }
        public bool? AnimationsEnabled { get; set; }
        public DateTime? AnnouncementsLastSeen { get; set; }
        public double? ChatChannelID { get; set; }
        public string ColorTheme { get; set; }
        public string Currency { get; set; }
        public bool? Debug { get; set; }
        public List<string> DisableEmails { get; set; }
        public List<string> HideConfirmDialogs { get; set; }
        public bool? HideConnectionModal { get; set; }
        public bool? HideFromLeaderboard { get; set; }
        public bool? HideNameFromLeaderboard { get; set; }
        public List<string> HideNotifications { get; set; }
        public string Locale { get; set; }
        public List<string> MsgsSeen { get; set; }
        public Object OrderBookBinning { get; set; }
        public string OrderBookType { get; set; }
        public bool? OrderClearImmediate { get; set; }
        public bool? OrderControlsPlusMinus { get; set; }
        public bool? ShowLocaleNumbers { get; set; }
        public List<string> Sounds { get; set; }
        public bool? StrictIPCheck { get; set; }
        public bool? StrictTimeout { get; set; }
        public string TickerGroup { get; set; }
        public bool? TickerPinned { get; set; }
        public string TradeLayout { get; set; }

    }
}
