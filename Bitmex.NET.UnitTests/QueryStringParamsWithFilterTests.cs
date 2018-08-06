using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bitmex.NET.UnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class QueryStringParamsWithFilterTests
    {
        [TestMethod]
        public void should_return_query_string_with_filter()
        {
            // arrange
            var sut = new SomeQueryStringParamsWithFilter
            {
                Filter = new Dictionary<string, string>
                {
                    {"symbol","XBTUSD" },
                    {"cnt","1" }
                },
                Value = "123"
            };

            // act
            var result = sut.ToQueryString();

            // assert
            result.Should().Be("val=123&filter=%7b%22symbol%22%3a%22XBTUSD%22%2c%22cnt%22%3a%221%22%7d");
        }

        private class SomeQueryStringParamsWithFilter : QueryStringParamsWithFilter
        {
            [DisplayName("val")]
            public string Value { get; set; }
        }
    }
}
