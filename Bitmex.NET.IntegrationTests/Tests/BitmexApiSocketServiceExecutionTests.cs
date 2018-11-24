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
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceExecutionsTests : BaseBitmexSocketIntegrationTests
    {
        private IBitmexApiService _bitmexApiService;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _bitmexApiService = Container.Resolve<IBitmexApiService>();

        }
        [TestMethod]
        public void should_subscribe_on_executions()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<ExecutionDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreateExecutionSubsription(a =>
                {
                    if (a.Data.Any())
                    {
                        dtos = a.Data;
                        dataReceived.Set();
                    }

                });

                Subscription = subscription;
                // act

                Sut.Subscribe(subscription);
                _bitmexApiService.Execute(BitmexApiUrls.Order.PostOrder,
                    OrderPOSTRequestParams.CreateSimpleMarket("XBTUSD", 10, OrderSide.Buy)).Wait();
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(30));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
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