using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Bitmex.NET.IntegrationTests.Tests
{
	[TestClass]
	public class BitmexApiServicePositionApiTests : IntegrationTestsClass<IBitmexApiService>
	{

		[TestMethod]
		public void should_get_all_the_positions()
		{
			// arrange
			var @params = new PositionGETRequestParams();

			// act
			var result = Sut.Execute(BitmexApiUrls.Position.GetPosition, @params).Result;

			// assert
			result.Should().NotBeNull();
			result.Count.Should().BeGreaterThan(0);
		}

		[TestMethod]
		public void should_get_the_positions_with_params()
		{
			// arrange
			var @params = new PositionGETRequestParams
			{
				// Filter doesn't work for this api method on Bitmex side, but it's implemented here as per API Reference
				Filter = new Dictionary<string, string> { { "symbol", "XBTUSD" } }
			};

			// act
			var result = Sut.Execute(BitmexApiUrls.Position.GetPosition, @params).Result;

			// assert
			result.Should().NotBeNull();
			result.Count.Should().BeGreaterThan(0);
		}

		[TestMethod]
		public void should_execute_position_isolate()
		{
			// arrange
			var @params = new PositionIsolatePOSTRequestParams
			{
				Symbol = "XBTUSD",
				Enabled = true
			};

			// act
			var result = Sut.Execute(BitmexApiUrls.Position.PostPositionIsolate, @params).Result;

			// assert
			result.Should().NotBeNull();
			result.Symbol.Should().Be("XBTUSD");
		}

		[TestMethod]
		public void should_execute_position_leverage()
		{
			// arrange
			var @params = new PositionLeveragePOSTRequestParams
			{
				Symbol = "XBTUSD",
				Leverage = 1
			};

			// act
			var result = Sut.Execute(BitmexApiUrls.Position.PostPositionLeverage, @params).Result;

			// assert
			result.Should().NotBeNull();
			result.Symbol.Should().Be("XBTUSD");
		}

		[TestMethod]
		public void should_execute_position_risk_limit()
		{
			// arrange
			var @params = new PositionRiskLimitPOSTRequestParams
			{
				Symbol = "XBTUSD",
				RiskLimit = 1
			};

			// act
			var result = Sut.Execute(BitmexApiUrls.Position.PostPositionRiskLimit, @params).Result;

			// assert
			result.Should().NotBeNull();
			result.Symbol.Should().Be("XBTUSD");
		}

		// works only for certain account conditions
		[TestMethod, Ignore]
		public void should_execute_position_transfer_margin()
		{
			// arrange
			var @params = new PositionTransferMarginPOSTRequestParams
			{
				Symbol = "XBTUSD",
				Amount = 1
			};

			// act
			var result = Sut.Execute(BitmexApiUrls.Position.PostPositionTransferMargin, @params).Result;

			// assert
			result.Should().NotBeNull();
			result.Symbol.Should().Be("XBTUSD");
		}
	}
}
