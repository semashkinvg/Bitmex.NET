using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bitmex.NET.Models
{
	public abstract class QueryStringParamsWithFilter : QueryStringParams
	{
        /// <summary>
        /// Generic table filter. Send JSON key/value pairs, such as {"key": "value"}. You can key on individual fields, and do more advanced querying on timestamps. See the Timestamp Docs for more details.
        /// </summary>
        [JsonProperty("filter")]
        public IDictionary<string, string> Filter { get; set; }

		public override string ToQueryString()
		{
			var baseQuery = base.ToQueryString();
			var filterValues = Filter?.Select(a => $"{a.Key}={HttpUtility.HtmlEncode(a.Value)}") ?? new List<string>();
			var currentQuery = $"{string.Join("&", filterValues)}";

			if (string.IsNullOrWhiteSpace(baseQuery))
			{
				return currentQuery;
			}
			if (string.IsNullOrWhiteSpace(currentQuery))
			{
				return baseQuery;
			}
			if (!string.IsNullOrWhiteSpace(currentQuery) && !string.IsNullOrWhiteSpace(baseQuery))
			{
				return baseQuery + "&" + currentQuery;
			}
			return string.Empty;
		}
	}
}
