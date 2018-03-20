using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bitmex.NET.UnitTests
{
	[TestClass]
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
			result.Should().Be("val=123&symbol=XBTUSD&cnt=1");
		}

		private class SomeQueryStringParamsWithFilter : QueryStringParamsWithFilter
		{
			[DisplayName("val")]
			public string Value { get; set; }
		}
	}
}
