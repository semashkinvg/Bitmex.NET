using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace Bitmex.NET.UnitTests
{
    [TestClass]
    [TestCategory("Unit")]
    public class QueryStringParamsTests
    {
        [TestMethod]
        public void should_create_params_string()
        {
            // arrange
            var sut = new SomeQueryStringParams
            {
                Value = "someValue"
            };

            // act

            var result = sut.ToQueryString();

            // assert
            result.Should().Be("val=someValue");
        }

        [TestMethod]
        public void should_create_params_string_with_two_params()
        {
            // arrange
            var sut = new WithTwoQueryStringParams
            {
                Value = "someValue",
                Value1 = "someValue1"
            };

            // act

            var result = sut.ToQueryString();

            // assert
            result.Should().Be("val=someValue&val1=someValue1");
        }

        [DataTestMethod]
        [DataRow(true, "true")]
        [DataRow(false, "false")]
        public void should_return_bool_in_lower_case(bool input, string expected)
        {
            // arrange
            var sut = new SomeQueryBoolParams
            {
                Value = input
            };

            // act

            var result = sut.ToQueryString();

            // assert
            result.Should().Be($"val={expected}");
        }

        [DataTestMethod]
        [DataRow(true, "true")]
        [DataRow(false, "false")]
        [DataRow(null, "")]
        public void should_return_bool_nullable_in_lower_case(bool? input, string expected)
        {
            // arrange
            var sut = new SomeQueryBoolNullableParams
            {
                Value = input
            };

            // act

            var result = sut.ToQueryString();

            // assert
            result.Should().Be($"val={expected}");
        }

        private class SomeQueryStringParams : QueryStringParams
        {
            [DisplayName("val")]
            public string Value { get; set; }
        }
        private class SomeQueryBoolParams : QueryStringParams
        {
            [DisplayName("val")]
            public bool Value { get; set; }
        }
        private class SomeQueryBoolNullableParams : QueryStringParams
        {
            [DisplayName("val")]
            public bool? Value { get; set; }
        }

        private class WithTwoQueryStringParams : QueryStringParams
        {
            [DisplayName("val")]
            public string Value { get; set; }
            [DisplayName("val1")]
            public string Value1 { get; set; }
        }
    }
}
