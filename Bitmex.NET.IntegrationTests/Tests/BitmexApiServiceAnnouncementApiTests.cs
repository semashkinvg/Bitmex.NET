using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceAnnouncementApiTests : IntegrationTestsClass<IBitmexApiService>
    {

        [TestMethod]
        public void should_return_announcement_list()
        {
            // arrange
            var @params = new AnnouncementGETRequestParams()
            {
                
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Announcement.GetAnnouncement, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterOrEqualTo(1);
        }
      
        
    }
}
