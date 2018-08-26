using Bitmex.NET.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Bitmex.NET.IntegrationTests
{
    public class BaseBitmexIntegrationTests<T> : IntegrationTestsClass<T>
    {
        [TestCleanup]
        public override void TestCleanup()
        {
            DeleteAllOrders();
            base.TestCleanup();
        }

        private void DeleteAllOrders()
        {
            var @params = new OrderAllDELETERequestParams()
            {
                Symbol = "XBTUSD"
            };
            Container.Resolve<IBitmexApiService>().Execute(BitmexApiUrls.Order.DeleteOrderAll, @params).Wait();
            Container.Resolve<IBitmexApiService>().Execute(BitmexApiUrls.Order.PostOrder,
                OrderPOSTRequestParams.ClosePositionByMarket("XBTUSD")).Wait();
        }
    }
}
