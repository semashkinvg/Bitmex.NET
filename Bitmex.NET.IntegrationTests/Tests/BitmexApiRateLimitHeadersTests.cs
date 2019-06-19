using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiRateLimitHeadersTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_ratelimit_headers()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Stats.GetStats, @params).Result;

            // assert
            result.RateLimitLimit.Should().BeGreaterThan(0);
            result.RateLimitRemaining.Should().BeGreaterThan(0);
            result.RateLimitReset.Should().BeAfter(DateTime.UtcNow.AddSeconds(-2));
        }
      
        
    }
}
