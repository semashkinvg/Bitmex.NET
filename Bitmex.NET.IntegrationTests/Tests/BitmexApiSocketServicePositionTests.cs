
using Bitmex.NET.Dtos;
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
    // These tests can be failed sometime, it's because info through the socket comes a bit later or connection limit has been reached
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServicePositionTests : BaseBitmexIntegrationTests<IBitmexApiSocketService>
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
        public void should_receive_position_change_notification()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                var @params = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", 3, OrderSide.Buy);

                // act
                IList<PositionDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<PositionDto>>.Create(SubscriptionType.position, a =>
                {
                    dtos = a.ToList();
                    dataReceived.Set();
                }));

                var result = _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, @params).Result;
                result.Should().NotBeNull();
                result.OrdType.Should().Be("Market");
                result.OrdStatus.Should().Be("Filled");
                result.OrderId.Should().NotBeNull();

                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue("data hasn't received");
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }
    }
}
