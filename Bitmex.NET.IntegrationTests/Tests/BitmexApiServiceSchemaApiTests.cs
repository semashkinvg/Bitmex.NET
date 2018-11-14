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
    public class BitmexApiServiceSchemaApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_all_schemas()
        {
            // arrange
            var @params = new SchemaGETRequestParams
            {

            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Schema.GetSchema, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Keys.Count.Should().BeGreaterThan(0);
            result.Values.First().Keys.Length.Should().BeGreaterThan(0);
            result.Values.First().Types.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_chat_channel_schema()
        {
            // arrange
            var @params = new SchemaGETRequestParams
            {
                Model = "ChatChannel"
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Schema.GetSchema, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            var chatChannelSchema = result.First();
            chatChannelSchema.Key.Should().Be("ChatChannel");
            chatChannelSchema.Value.Keys[0].Should().Be("id");
            chatChannelSchema.Value.Types.Value<string>("id").Should().Be("integer");
        }

        [TestMethod]
        public void should_return_web_socket_help_schema()
        {
            // arrange
            var @params = new EmptyParameters()
            {
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Schema.GetSchemaWebsocketHelp, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Info.Should().NotBeNullOrEmpty();
            result.Subscribe.Should().NotBeNullOrEmpty();
            result.Usage.Should().NotBeNullOrEmpty();
            result.Ops.Length.Should().BeGreaterThan(0);
            result.SubscriptionSubjects.Keys.Count.Should().BeGreaterThan(0);
            result.SubscriptionSubjects["public"].Should().Contain("chat");

        }
    }
}
