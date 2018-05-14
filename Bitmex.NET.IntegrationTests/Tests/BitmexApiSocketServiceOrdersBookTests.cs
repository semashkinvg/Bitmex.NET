using Bitmex.NET.Dtos;
using Bitmex.NET.Dtos.Socket;
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
	public class BitmexApiSocketServiceOrdersBookTests : IntegrationTestsClass<IBitmexApiSocketService>
	{

		[TestMethod]
		public void should_subscribe_on_orders_book_10()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<OrderBookSocketDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<OrderBookSocketDto>>.Create(SubscriptionType.orderBook10, a =>
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
		public void should_subscribe_on_orders_book_10_with_arguments()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<OrderBookSocketDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<OrderBookSocketDto>>.Create(SubscriptionType.orderBook10, a =>
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
		public void should_subscribe_on_orders_book_L2()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<OrderBookDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<OrderBookDto>>.Create(SubscriptionType.orderBookL2, a =>
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
		public void should_subscribe_on_orders_book_L2_with_arguments()
		{
			// arrange
			var connected = Sut.Connect();

			// act
			IEnumerable<OrderBookDto> dtos = null;
			var dataReceived = new ManualResetEvent(false);
			Sut.Subscribe(BitmexApiSubscriptionInfo<IEnumerable<OrderBookDto>>.Create(SubscriptionType.orderBookL2, a =>
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
	}
}
