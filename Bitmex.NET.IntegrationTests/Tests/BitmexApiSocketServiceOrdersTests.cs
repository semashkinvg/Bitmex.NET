
using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
using Bitmex.NET.Models;
using Bitmex.NET.Models.Socket;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity;

namespace Bitmex.NET.IntegrationTests.Tests
{
    // This test can be fail sometime, it's because info through the socket comes a bit later or connection limit has been eached
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceOrdersTests : BaseBitmexSocketIntegrationTests
    {
        private decimal _xbtAvgPrice;
        private IBitmexApiService _bitmexApiService;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _bitmexApiService = Container.Resolve<IBitmexApiService>();
            var paramCloseAfter = new OrderCancelAllAfterPOSTRequestParams
            {
                Timeout = int.MaxValue
            };

            _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrderCancelAllAfter, paramCloseAfter).Wait();
            _xbtAvgPrice = _bitmexApiService.Execute(BitmexApiUrls.OrderBook.GetOrderBookL2, new OrderBookL2GETRequestParams() { Symbol = "XBTUSD", Depth = 1 }).Result.First()
                .Price;

        }

        [TestMethod]
        public void should_receive_limit_order_notification()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                var @params = OrderPOSTRequestParams.CreateSimpleHidenLimit("XBTUSD", 3, _xbtAvgPrice - 500, OrderSide.Buy);

                // act
                IList<OrderDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmexApiSubscriptionInfo<IEnumerable<OrderDto>>.Create(SubscriptionType.order, a =>
                {
                    if (a.Data.Any(b => b.Symbol == "XBTUSD") && a.Action == BitmexActions.Insert)
                    {
                        dtos = a.Data.ToList();
                        dataReceived.Set();
                    }
                });

                Subscription = subscription;

                Sut.Subscribe(subscription);
                var result = _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, @params).Result;
                result.Should().NotBeNull();
                //result.OrdType.Should().Be("Limit");
                result.OrdStatus.Should().Be("New");
                result.OrderId.Should().NotBeNull();

                Thread.Sleep(2000);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos[0].OrdType.Should().Be("Limit");
                dtos[0].OrdStatus.Should().Be("New");
                dtos[0].OrderId.Should().Be(result.OrderId);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }

        [TestMethod]
        public void should_receive_market_buy_order_notification()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                var @params = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", 3, OrderSide.Buy);

                // act
                IList<OrderDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmexApiSubscriptionInfo<IEnumerable<OrderDto>>.Create(SubscriptionType.order, a =>
                {
                    if (a.Data.Any(b => b.Symbol == "XBTUSD") && a.Action == BitmexActions.Insert)
                    {
                        dtos = a.Data.ToList();
                        dataReceived.Set();
                    }
                });

                Subscription = subscription;

                Sut.Subscribe(subscription);
                var result = _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, @params).Result;
                result.Should().NotBeNull();
                result.OrdType.Should().Be("Market");
                result.OrdStatus.Should().Be("Filled");
                result.OrderId.Should().NotBeNull();

                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos[0].OrderId.Should().Be(result.OrderId);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }

        [TestMethod]
        public void should_receive_market_sell_order_notification()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                var @params = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", 3, OrderSide.Sell);

                // act
                IList<OrderDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmexApiSubscriptionInfo<IEnumerable<OrderDto>>.Create(SubscriptionType.order, a =>
                {
                    if (a.Data.Any(b => b.Symbol == "XBTUSD") && a.Action == BitmexActions.Insert)
                    {
                        dtos = a.Data.ToList();
                        dataReceived.Set();
                    }
                });

                Subscription = subscription;

                Sut.Subscribe(subscription);
                var result = _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, @params).Result;
                result.Should().NotBeNull();
                result.OrdType.Should().Be("Market");
                result.OrdStatus.Should().Be("Filled");
                result.OrderId.Should().NotBeNull();

                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos[0].OrderId.Should().Be(result.OrderId);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }
    }
}
