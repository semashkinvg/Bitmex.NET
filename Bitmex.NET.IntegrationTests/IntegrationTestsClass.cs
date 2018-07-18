using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using Unity;

namespace Bitmex.NET.IntegrationTests
{
    public class IntegrationTestsClass<T>
    {
        protected T Sut;
        protected UnityContainer Container;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            Container = new UnityContainer();
            Container.AddNewExtension<BitmexNetUnityExtension>();

            Sut = Container.Resolve<T>();
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            Container?.Dispose();
            var disposable = Sut as IDisposable;
            disposable?.Dispose();

            // to make avoid issues with nonce becuase nonce provided reregistered all the time
            Thread.Sleep(5000);
        }
    }
}
