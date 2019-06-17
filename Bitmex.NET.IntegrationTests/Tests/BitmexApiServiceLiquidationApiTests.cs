using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceLiquidationApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_liquidationss_list()
        {
            // arrange
            var @params = new LiquidationGETRequestParams()
            {
                Count = 100                              
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Liquidation.GetLiquidation, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
          

        }


    }
}
