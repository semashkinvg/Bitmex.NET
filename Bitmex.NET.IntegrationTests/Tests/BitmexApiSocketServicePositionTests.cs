
using Bitmex.NET.Dtos;
using Bitmex.NET.Models;
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
    public class BitmexApiSocketServicePositionTests : BaseBitmexSocketIntegrationTests
    {
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

        }

        [TestMethod]
        public void should_receive_position_change_notification()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                var @params = OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", 3, OrderSide.Buy);
                IList<PositionDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreatePositionSubsription(a =>
                {
                    dtos = a.Data.ToList();
                    dataReceived.Set();
                });

                Subscription = subscription;

                // act

                Sut.Subscribe(subscription);

                var result = _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder, @params).Result.Result;
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
