using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceStatsApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_stats()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Stats.GetStats, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterOrEqualTo(1);
        }
        [TestMethod]
        public void should_return_stats_history()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Stats.GetStatsHistory, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterOrEqualTo(1);
        }
        [TestMethod]
        public void should_return_stats_history_usd()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Stats.GetStatsHistoryUsd, @params).Result.Result;

            // assert
            result.Should().NotBeNull();            
            result.Count.Should().BeGreaterOrEqualTo(1);
        }
    }
}
