using Bitmex.NET.Models.Socket;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Bitmex.NET.IntegrationTests
{
    public class BaseBitmexSocketIntegrationTests : BaseBitmexIntegrationTests<IBitmexApiSocketService>
    {
        /// <summary>
        /// Used to avoid exciding subscription limitation within the tests
        /// Each test that subscribes on something has to initialize this field. It will be released automaticaly after test completion
        /// </summary>
        protected BitmexApiSubscriptionInfo Subscription;

        [TestCleanup]
        public override void TestCleanup()
        {
            Unsibscribe();
            base.TestCleanup();
        }

        private void Unsibscribe()
        {
            if (Subscription != null)
            {
                try
                {
                    Sut.Unsubscribe(Subscription);
                }
                catch (Exception e)
                {
                    // there the outstanding test to test unsubscription, so we mute exception here
                    Debug.WriteLine(e);
                }
            }
        }
    }
}
