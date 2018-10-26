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
    public class BitmexApiSocketServiceUnsubscribeTests : BaseBitmexIntegrationTests<IBitmexApiSocketService>
    {
        [TestMethod]
        public void should_unsubscribe()
        {
            try
            {
                // arrange
                var connected = Sut.Connect();
                IEnumerable<InstrumentDto> dto = null;
                var dataReceived = new ManualResetEvent(false);
                var subscription = BitmetSocketSubscriptions.CreateInstrumentSubsription(a =>
                {
                    dto = a.Data;
                    dataReceived.Set();
                });
                Sut.Subscribe(subscription);
                var received = dataReceived.WaitOne(TimeSpan.FromSeconds(5));

                // intermediate assert
                // no exception raised
                connected.Should().BeTrue();
                received.Should().BeTrue();
                dto.Should().NotBeNull();
                dto.Count().Should().BeGreaterThan(0);


                // act
                Sut.Unsubscribe(subscription);

                // assert
                // no exceptions raised

            }
            catch (BitmexWebSocketLimitReachedException)
            {
                Assert.Inconclusive("connection limit reached");
            }
        }
    }
}
