using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceSettlementApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_settlements()
        {
            // arrange
            var @params = new SettlementGETRequestParams
            {
                Symbol = "XBTUSD",
                Count = 25,
                Reverse = true,
                EndTime = new DateTime(2018,10,10,0,0,0)
                
                
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Settlement.GetSettlement, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(25);
            result.First().TimeStamp.Value.Should().BeAfter(result.Last().TimeStamp.Value);
            result.First().TimeStamp.Value.Should().BeOnOrBefore(new DateTime(2018, 10, 10, 0, 0, 0));
            result.First().Symbol.Should().Be("XBTUSD");

        }

  
    }
}
