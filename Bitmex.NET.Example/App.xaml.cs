using Bitmex.NET.Example.Automapping;
using System.Windows;

namespace Bitmex.NET.Example
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			AutoMapperConfiguration.Configure();
			base.OnStartup(e);
		}
	}
}
