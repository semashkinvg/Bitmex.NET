using System.Collections.Generic;

namespace Bitmex.NET.Models
{
	public static class Environments
	{
		public static readonly IDictionary<BitmexEnvironment, string> Values = new Dictionary<BitmexEnvironment, string>
		{
			{BitmexEnvironment.Test, "testnet.bitmex.com"},
			{BitmexEnvironment.Prod, "www.bitmex.com"}
		};

	}
}
