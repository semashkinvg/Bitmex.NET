using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmex.NET.Models
{
    public partial class OrderPOSTRequestParams
    {
        public static OrderPOSTRequestParams CreateSimpleMarket(string symbol, int quantity, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Market),
            };
        }

        public static OrderPOSTRequestParams CreateSimpleLimit(string symbol, int quantity, double price, OrderSide side)
        {
            return new OrderPOSTRequestParams
            {
                Symbol = symbol,
                Side = Enum.GetName(typeof(OrderSide), side),
                OrderQty = quantity,
                OrdType = Enum.GetName(typeof(OrderType), OrderType.Limit),
                DisplayQty= 0,
                Price = price,
                ExecInst = "ParticipateDoNotInitiate",
            };
        }

        public static OrderPOSTRequestParams CreateMarketStopOrder(string symbol, int quantity, double stopPrice, OrderSide side)
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

        public static OrderPOSTRequestParams CreateLimitStopOrder(string symbol, int quantity, double stopPrice, double price, OrderSide side)
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
