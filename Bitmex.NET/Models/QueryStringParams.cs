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

            var @params = props.Select(a =>
                {
                    if (a.Prop.PropertyType == typeof(DateTime?))
                    {
                        return $"{a.DisplayNameAttr.DisplayName}={((DateTime?)a.Prop.GetValue(this))?.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'")}";
                    }

                    if (a.Prop.PropertyType == typeof(bool?) || a.Prop.PropertyType == typeof(bool))
                    {
                        return $"{a.DisplayNameAttr.DisplayName}={((bool?)a.Prop.GetValue(this))?.ToString().ToLowerInvariant()}";
                    }

                    return $"{a.DisplayNameAttr.DisplayName}={HttpUtility.UrlEncode(a.Prop.GetValue(this)?.ToString())}";
                });

            return $"{string.Join("&", @params)}";
        }
    }
}
