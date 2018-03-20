using Newtonsoft.Json;

namespace Bitmex.NET.Models
{
	public abstract class QueryJsonParams : IJsonQueryParams
	{
		public string ToJson()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
