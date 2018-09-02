using Bitmex.NET.Models;
using System.Threading.Tasks;

namespace Bitmex.NET
{
    public interface IBitmexApiProxy
    {
        Task<string> Get(string action, IQueryStringParams parameters);
        Task<string> Post(string action, IJsonQueryParams parameters);
        Task<string> Put(string action, IJsonQueryParams parameters);
        Task<string> Delete(string action, IQueryStringParams parameters);
    }
}
