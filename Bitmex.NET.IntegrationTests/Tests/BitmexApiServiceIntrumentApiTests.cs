using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceIntrumentApiTests : IntegrationTestsClass<IBitmexApiService>
    {
        [TestMethod]
        public void should_return_instruments()
        {
            // arrange
            var @params = new InstrumentGETRequestParams
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrument, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_instruments_by_symbol()
        {
            // arrange
            var @params = new InstrumentGETRequestParams
            {
                Symbol = "XBTUSD"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrument, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result[0].Symbol.Should().Be("XBTUSD");
        }

        [TestMethod]
        public void should_return_all_active_instruments()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrumentActive, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_all_active_instruments_and_indices()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrumentActiveAndIndices, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_all_active_intervals()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrumentActiveIntervals, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Intervals.Length.Should().BeGreaterThan(0);
            result.Symbols.Length.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void should_return_composite_indexes()
        {
            // arrange
            var @params = new InstrumentCompositeIndexGETRequestParams
            {
                Symbol = "XBT"
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrumentCompositeIndex, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_instrument_indices()
        {
            // arrange
            var @params = new EmptyParameters
            {
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.Instrument.GetInstrumentIndices, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }
    }
}
