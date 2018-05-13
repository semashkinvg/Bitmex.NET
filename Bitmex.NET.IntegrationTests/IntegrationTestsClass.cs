using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;

namespace Bitmex.NET.IntegrationTests
{
	public class IntegrationTestsClass<T>
	{
		protected T Sut;

		[TestInitialize]
		public virtual void TestInitialize()
		{
			var container = new UnityContainer();
			container.AddNewExtension<BitmexNetUnityExtension>();

			Sut = container.Resolve<T>();
		}
	}
}
