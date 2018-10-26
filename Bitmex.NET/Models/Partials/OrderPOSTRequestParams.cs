using System;

namespace Bitmex.NET.Models
{
    public partial class OrderPOSTRequestParams
    {
        public static OrderPOSTRequestParams ClosePositionByMarket(string symbol)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                ExecInst = "Close"
            };
        }
        public static OrderPOSTRequestParams ClosePositionByLimit(string symbol, decimal price)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                ExecInst = "Close",
                Price = price
            };
        }

        public static OrderPOSTRequestParams CreateSimpleMarket(string symbol, decimal quantity, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Market),
            };
        }

        public static OrderPOSTRequestParams CreateSimpleLimit(string symbol, decimal quantity, decimal price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Limit),
                DisplayQty = quantity,
                Price = price,
                ExecInst = "ParticipateDoNotInitiate",
            };
        }

        /// <summary>
        /// Be aware that bitmex takes fee for hiden limit orders
        /// </summary>
        public static OrderPOSTRequestParams CreateSimpleHidenLimit(string symbol, decimal quantity, decimal price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Limit),
                DisplayQty = 0,
                Price = price,
                ExecInst = "ParticipateDoNotInitiate",
            };
        }

        public static OrderPOSTRequestParams CreateMarketStopOrder(string symbol, decimal quantity, decimal stopPrice, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Stop),
                StopPx = stopPrice,
                ExecInst = "ReduceOnly,LastPrice",
            };
        }

        public static OrderPOSTRequestParams CreateLimitStopOrder(string symbol, decimal quantity, decimal stopPrice, decimal price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Stop),
                StopPx = stopPrice,
                Price = price,
                ExecInst = "ReduceOnly,LastPrice",
            };
        }
    }
}
