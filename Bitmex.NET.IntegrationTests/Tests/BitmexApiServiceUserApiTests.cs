using Bitmex.NET.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Bitmex.NET.IntegrationTests.Tests
{
    [TestClass]
    [TestCategory("REST")]
    public class BitmexApiServiceUserApiTests : IntegrationTestsClass<IBitmexApiService>
    {
        [TestMethod]
        public void should_return_user()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUser, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Email.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void should_return_user_affiliate_status()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserAffiliateStatus, @params).Result.Result;

            // assert
            // returns nothing for test account
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_comission()
        {
            // arrange
            var @params = new EmptyParameters();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserCommission, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [TestMethod]
        public void should_return_user_margin()
        {
            // arrange
            var @params = new UserMarginGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserMargin, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Amount.Should().NotBeNull();
            result.Currency.Should().NotBeNull();
        }

        [TestMethod, Ignore("Not Found, Code:HTTPError")]
        public void should_check_referral_code()
        {
            // arrange
            var @params = new UserCheckReferralCodeGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserCheckReferralCode, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_deposite_address()
        {
            // arrange
            var @params = new UserDepositAddressGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserDepositAddress, @params).Result.Result;

            // assert
            result.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void should_return_wallet()
        {
            // arrange
            var @params = new UserWalletGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserWallet, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Amount.Should().NotBeNull();
            result.Currency.Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_wallet_history()
        {
            // arrange
            var @params = new UserWalletHistoryGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserWalletHistory, @params).Result.Result;

            // assert
            result.Should().NotBeNullOrEmpty();
            result.First().TransactId.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void should_return_wallet_summary()
        {
            // arrange
            var @params = new UserWalletSummaryGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserWalletSummary, @params).Result.Result;

            // assert
            result.Should().NotBeNullOrEmpty();
            result.First().Account.Should().NotBeNull();
        }

        [TestMethod]
        public void should_return_min_withdrawal_fee()
        {
            // arrange
            var @params = new UserMinWithdrawalFeeGETRequestParams();
            {

            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.GetUserMinWithdrawalFee, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Currency.Should().Be("XBt");
        }

        [TestMethod, Ignore("Access Denied, Code:HTTPError")]
        public void should_update_user_data()
        {
            // arrange
            var @params = new UserPUTRequestParams
            {
                Firstname = Guid.NewGuid().ToString("N")
            };

            // act
            var result = Sut.Execute(BitmexApiUrls.User.PutUser, @params).Result.Result;

            // assert
            result.Should().NotBeNull();
            result.Firstname.Should().Be(@params.Firstname);
        }
    }
}
