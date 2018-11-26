using Bitmex.NET.Dtos;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("WebSocket")]
    public class BitmexApiSocketServiceFundingTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_subscribe_on_funding()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<FundingDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreateFundingSubscription(a =>
                {
                    dtos = a.Data;
                    dataReceived.Set();
                });

                Subscription = subscription;
                // act

                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

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

        [TestMethod]
        public void should_subscribe_on_funding_with_arguments()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<FundingDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreateFundingSubscription(a =>
                {
                    dtos = a.Data;
                    dataReceived.Set();
                }).WithArgs("XBTUSD");

                Subscription = subscription;

                // act
                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(60));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos.All(a => a.Symbol == "XBTUSD").Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }

    }
}
