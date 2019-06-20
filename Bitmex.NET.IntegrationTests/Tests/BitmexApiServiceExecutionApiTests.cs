using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceExecutionApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_executions()
        {
            // arrange
            var @params = new ExecutionGETRequestParams
            {
                Symbol = "XBTUSD"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Execution.GetExecution, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_balance_affecting_executions()
        {
            // arrange
            var @params = new ExecutionTradeHistoryGETRequestParams()
            {
                Symbol = "XBTUSD"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Execution.GetExecutionTradeHistory, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}