using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bitmex.NET.Models
{
	public abstract class QueryStringParams : IQueryStringParams
	{
		public virtual string ToQueryString()
		{
			var props = this.GetType().GetProperties().Where(a => a.GetCustomAttributes<DisplayNameAttribute>().Any())
				.Select(
					a => new
					{
						DisplayNameAttr = a.GetCustomAttributes<DisplayNameAttribute>().First(),
						Prop = a
					});
			//var @params = props.Select(a => $"{a.DisplayNameAttr.DisplayName}={HttpUtility.HtmlEncode(a.Prop.GetValue(this))}");
            var @params = props.Select(a => $"{a.DisplayNameAttr.DisplayName}={HttpUtility.HtmlEncode(a.Prop.PropertyType.Equals(typeof(DateTime?)) ? ((DateTime?)a.Prop.GetValue(this))?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'") : a.Prop.GetValue(this))}");

            return $"{string.Join("&", @params)}";
		}
	}
}
