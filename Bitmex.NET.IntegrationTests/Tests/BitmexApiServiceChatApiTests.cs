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
    public class BitmexApiServiceChatApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_count_connected_users_and_bots()
        {
            // arrange
            var @params = new EmptyParameters();
            {
              
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Chat.GetChatConnected, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Bots.Should().BeGreaterThan(0);
            result.Users.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_all_chat_channels()
        {
            // arrange
            var @params = new EmptyParameters()
            {

            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Chat.GetChatChannels, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
            result.First().ChannelId.Should().Be(1);
            result.First().Name.Should().Be("English");
        }

        [TestMethod]
        public void should_return_posted_chat_message()
        {
            // arrange
            var @params = new ChatPOSTRequestParams()
            {
                Message = "Long Live Bitmex.NET",
                //English channel
                ChannelID = 1,

            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Chat.PostChat, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            result.Date.Should().NotBeNull();
            result.Html.Should().NotBeNullOrEmpty();
            result.User.Should().NotBeNullOrEmpty();
            result.ChannelId.Should().Be(1);
            result.Message.Should().Be("Long Live Bitmex.NET");
            result.FromBot.Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_the_chat_message()
        {
            // arrange
            var @params = new ChatGETRequestParams
            {
               
                Count = 35,
                Start = 5000,
                Reverse = false,
                ChannelID = 2
            };
            // act
            var result = Sut.Execute(BitmexApiUrls.Chat.GetChat, @params).Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(35);
            var firstChatMessage = result.First();
            var lastChatMessage = result.Last();
            firstChatMessage.Id.Should().BeGreaterThan(4999);
            firstChatMessage.Id.Value.Should().BeLessThan(lastChatMessage.Id.Value);
            firstChatMessage.ChannelId.Should().Be(2);
            firstChatMessage.Date.Should().NotBeNull();
            firstChatMessage.User.Should().NotBeNullOrEmpty();
            firstChatMessage.FromBot.Should().NotBeNull();
            firstChatMessage.Html.Should().NotBeNullOrEmpty();
            firstChatMessage.Message.Should().NotBeNullOrEmpty();
        }

    }
}
