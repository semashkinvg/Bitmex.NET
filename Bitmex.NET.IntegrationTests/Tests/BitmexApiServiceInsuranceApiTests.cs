using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceInsuranceApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_insurance_list()
        {
            // arrange
            var @params = new InsuranceGETRequestParams()
            {
                Filter = null,
                Count = 41,
                Reverse = true,
                StartTime = DateTime.UtcNow.AddDays(-42)
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Insurance.GetInsurance, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(41);

        }


    }
}
