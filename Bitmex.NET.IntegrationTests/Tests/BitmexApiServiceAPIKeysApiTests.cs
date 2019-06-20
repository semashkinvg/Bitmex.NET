using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceAPIKeysApiTests : IntegrationTestsClass<IBitmexApiService>
    {
        string currentKey = ConfigurationManager.AppSettings["Key"];     
        [TestMethod]
        public void should_return_all_user_api_keys_and_test_disable_and_enable()
        {
            // arrange
            var @params = new ApiKeyGETRequestParams()
            {
                
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.APIKey.GetApiKey, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
           
        }

        

    }
}
