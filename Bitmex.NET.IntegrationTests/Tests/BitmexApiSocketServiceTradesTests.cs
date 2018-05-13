using Bitmex.NET.Dtos;
using Bitmex.NET.Models.Socket;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bitmex.NET.IntegrationTests.Tests
{
	[TestClass]
	public class BitmexApiSocketServiceTradesTests : IntegrationTestsClass<IBitmexApiSocketService>
	{

		[TestMethod]
		public void should_subscribe_on_trades()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<TradeDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<TradeDto>>.Create(SubscriptionType.trade, a =>
			{
				dtos = a;
				dataReceived.Set();
			}));
			var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

			// assert
			// no exception raised
			connected.Should().BeTrue();
			received.Should().BeTrue();
			dtos.Should().NotBeNull();
			dtos.Count().Should().BeGreaterThan(0);
		}

		[TestMethod]
		public void should_subscribe_on_trades_with_arguments()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<TradeDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<TradeDto>>.Create(SubscriptionType.trade, a =>
			{
				dtos = a;
				dataReceived.Set();
			}).WithArgs("XBTUSD"));
			var received = dataReceived.WaitOne(TimeSpan.FromSeconds(20));

			// assert
			// no exception raised
			connected.Should().BeTrue();
			received.Should().BeTrue();
			dtos.Should().NotBeNull();
			dtos.Count().Should().BeGreaterThan(0);
			dtos.All(a => a.Symbol == "XBTUSD").Should().BeTrue();
		}

		[TestMethod]
		public void should_subscribe_on_trades1m_with_arguments()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<TradeDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<TradeDto>>.Create(SubscriptionType.tradeBin1m, a =>
			{
				dtos = a;
				dataReceived.Set();
			}).WithArgs("XBTUSD"));
			var received = dataReceived.WaitOne(TimeSpan.FromSeconds(60));

			// assert
			// no exception raised
			connected.Should().BeTrue();
			received.Should().BeTrue();
			dtos.Should().NotBeNull();
			dtos.Count().Should().BeGreaterThan(0);
			dtos.All(a => a.Symbol == "XBTUSD").Should().BeTrue();
		}
	}
}
