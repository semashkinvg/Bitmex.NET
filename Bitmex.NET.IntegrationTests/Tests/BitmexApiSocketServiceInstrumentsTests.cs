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
    public class BitmexApiSocketServiceInstrumentsTests : BaseBitmexSocketIntegrationTests
    {
        [TestMethod]
        public void should_connect_and_be_authorized()
        {
            try
            {
                // act
                var result = Sut.Connect();

                // assert
                result.Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }

        [TestMethod]
        public void should_reconnect()
        {
            try
            {
                // act
                var result = Sut.Connect();
                var result2 = Sut.Connect();
                // assert
                (result && result2).Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }

        }

        [TestMethod]
        public void should_subscribe_on_all_instruments()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();

                // act
                IEnumerable<InstrumentDto> dto = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreateInstrumentSubsription(a =>
                {
                    dto = a.Data;
                    dataReceived.Set();
                });

                Subscription = subscription;

                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(5));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dto.Should().NotBeNull();
                dto.Count().Should().BeGreaterThan(0);
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }

        [TestMethod]
        public void should_subscribe_on_all_instruments_with_args()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();

                // act
                IEnumerable<InstrumentDto> dtos = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreateInstrumentSubsription(a =>
                {
                    dtos = a.Data;
                    dataReceived.Set();
                }).WithArgs("XBTJPY");

                Subscription = subscription;
                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(30));

                // assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dtos.Should().NotBeNull();
                dtos.Count().Should().BeGreaterThan(0);
                dtos.All(a => a.Symbol == "XBTJPY").Should().BeTrue();
            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }
    }
}
