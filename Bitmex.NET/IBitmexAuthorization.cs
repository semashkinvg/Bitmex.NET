using Bitmex.NET.Models;

namespace Bitmex.NET
{
	public interface IBitmexAuthorization
	{
		BitmexEnvironment BitmexEnvironment { get; set; }
		string Key { get; set; }
		string Secret { get; set; }
	}
}
