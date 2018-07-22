using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models.Socket;
using System;
using System.Collections.Generic;

namespace Bitmex.NET
{
    public static class BitmetSocketSubscriptions
    {
        public static BitmexApiSubscriptionInfo<IEnumerable<InstrumentDto>> CreateInstrumentSubsription(Action<BitmexSocketDataMessage<IEnumerable<InstrumentDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<InstrumentDto>>.Create(SubscriptionType.instrument, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<OrderBook10Dto>> CreateOrderBook10Subsription(Action<BitmexSocketDataMessage<IEnumerable<OrderBook10Dto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<OrderBook10Dto>>.Create(SubscriptionType.orderBook10, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<OrderBookDto>> CreateOrderBookL2Subsription(Action<BitmexSocketDataMessage<IEnumerable<OrderBookDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<OrderBookDto>>.Create(SubscriptionType.orderBookL2, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<OrderDto>> CreateOrderSubsription(Action<BitmexSocketDataMessage<IEnumerable<OrderDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<OrderDto>>.Create(SubscriptionType.order, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<PositionDto>> CreatePositionSubsription(Action<BitmexSocketDataMessage<IEnumerable<PositionDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<PositionDto>>.Create(SubscriptionType.position, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<TradeDto>> CreateTradeSubsription(Action<BitmexSocketDataMessage<IEnumerable<TradeDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<TradeDto>>.Create(SubscriptionType.trade, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>> CreateTradeBucket1MSubsription(Action<BitmexSocketDataMessage<IEnumerable<TradeBucketedDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>>.Create(SubscriptionType.tradeBin1m, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>> CreateTradeBucket5MSubsription(Action<BitmexSocketDataMessage<IEnumerable<TradeBucketedDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>>.Create(SubscriptionType.tradeBin5m, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>> CreateTradeBucket1HSubsription(Action<BitmexSocketDataMessage<IEnumerable<TradeBucketedDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>>.Create(SubscriptionType.tradeBin1h, act);
        }

        public static BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>> CreateTradeBucket1DSubsription(Action<BitmexSocketDataMessage<IEnumerable<TradeBucketedDto>>> act)
        {
            return BitmexApiSubscriptionInfo<IEnumerable<TradeBucketedDto>>.Create(SubscriptionType.tradeBin1d, act);
        }
    }
}
