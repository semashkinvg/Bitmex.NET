using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceLeaderBoardApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_leaderboard_list()
        {
            // arrange
            var @params = new LeaderboardGETRequestParams()
            {
                Method = "ROE"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Leaderboard.GetLeaderboard, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterOrEqualTo(1);
        }

        [TestMethod]
        public void should_return_user_leaderboard_alias()
        {
            // arrange
            var @params = new EmptyParameters()
            {
              
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Leaderboard.GetLeaderboardName, @params).Result.Result;
            // assert
            result.Should().NotBeNull();            
        }
    }
}
