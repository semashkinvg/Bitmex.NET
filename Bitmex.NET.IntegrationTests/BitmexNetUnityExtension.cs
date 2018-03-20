using Bitmex.NET.Models;
using System;
using System.Configuration;
using Unity;
using Unity.Extension;

namespace Bitmex.NET.IntegrationTests
{
	public sealed class BitmexNetUnityExtension : UnityContainerExtension
	{
		protected override void Initialize()
		{
			Container.RegisterType<IBitmexApiProxy, BitmexApiProxy>();
			Container.RegisterType<IBitmexApiService, BitmexApiService>();

			var authorization = new BitmexAuthorization
			{
				Key = ConfigurationManager.AppSettings["Key"],
				Secret = ConfigurationManager.AppSettings["Secret"],
				BitmexEnvironment =
					(BitmexEnvironment)Enum.Parse(typeof(BitmexEnvironment), ConfigurationManager.AppSettings["Environment"]),
			};

			Container.RegisterInstance<IBitmexAuthorization>(authorization);
		}
	}
}
