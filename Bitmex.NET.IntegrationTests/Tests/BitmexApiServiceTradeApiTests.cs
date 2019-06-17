using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceTradeApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_trades()
        {
            // arrange
            var @params = new TradeGETRequestParams
            {
                Symbol = "XBTUSD"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Trade.GetTrade, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_trades_with_specific_count()
        {
            // arrange
            var @params = new TradeGETRequestParams
            {
                Symbol = "XBTUSD",
                Count = 50
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Trade.GetTrade, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(50);
        }

        [TestMethod]
        public void should_return_trades_bucketed()
        {
            // arrange
            var @params = new TradeBucketedGETRequestParams
            {
                BinSize = "1m",
                Symbol = "XBTUSD"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Trade.GetTradeBucketed, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}
