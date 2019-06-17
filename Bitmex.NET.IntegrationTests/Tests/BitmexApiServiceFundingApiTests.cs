using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceFundingApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_fundings_list()
        {
            // arrange
            var @params = new FundingGETRequestParams()
            {
                Filter = null,
                Count = 10,
                Reverse = true,
                StartTime = DateTime.UtcNow.AddDays(-42)                
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Funding.GetFunding, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(10);

        }


    }
}
