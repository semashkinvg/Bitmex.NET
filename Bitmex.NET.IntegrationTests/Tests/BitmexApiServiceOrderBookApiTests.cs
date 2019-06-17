using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceOrderBookApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_orderbook_with_certain_depth()
        {
            // arrange
            var @params = new OrderBookL2GETRequestParams()
            {
                Symbol = "XBTUSD",
                Depth = 2
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.OrderBook.GetOrderBookL2, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(4);
        }
    }
}
