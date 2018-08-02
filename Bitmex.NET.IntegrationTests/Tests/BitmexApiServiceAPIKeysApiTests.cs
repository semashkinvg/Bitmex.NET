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
            var result = Sut.Execute(BitmexApiUrls.APIKey.GetApiKey, @params).Result;

            // assert

            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
            //string keyToDisable = result.Where(c => c.Id != currentKey&&c.Enabled.HasValue&&c.Enabled.Value).FirstOrDefault().Id;
            //should_disable_key(keyToDisable);
            //should_enable_key(keyToDisable);
        }

        // [TestMethod]
        public void should_disable_key(string key)
        {
            // arrange

            var @params = new ApiKeyDisablePOSTRequestParams()
            {
                ApiKeyID = key
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.APIKey.PostApiKeyDisable, @params).Result;

            // assert

            result.Enabled.Should().Be(false);
          
        }
        public void should_enable_key(string key)
        {
            // arrange

            var @params = new ApiKeyEnablePOSTRequestParams()
            {
                ApiKeyID = key
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.APIKey.PostApiKeyEnable, @params).Result;

            // assert

            result.Enabled.Should().Be(true);

        }

    }
}
