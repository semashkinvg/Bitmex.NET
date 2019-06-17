using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass, Ignore("this API doesn't work from ~2018-08-03")]
    [TestCategory("REST")]
    public class BitmexApiServiceQuoteApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_quotes()
        {
            // arrange
            var @params = new QuoteGETRequestParams
            {
                Symbol = "XBTUSD"
            };


            // act
            var result = Sut.Execute(BitmexApiUrls.Quote.GetQuote, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_quotes_with_specific_count()
        {
            // arrange
            var @params = new QuoteGETRequestParams
            {
                Symbol = "XBTUSD",
                Count = 50
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Quote.GetQuote, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(50);
        }

        [TestMethod]
        public void should_return_quotes_bucketed()
        {
            // arrange
            var @params = new QuoteBucketedGETRequestParams
            {
                BinSize = "1m",
                Symbol = "XBTUSD",
                Count = 500
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Quote.GetQuoteBucketed, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}
