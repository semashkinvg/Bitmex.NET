using System.Threading.Tasks;

namespace Bitmex.NET
{
	public interface IBitmexApiService
	{
		Task<BitmexApiResult<TResult>> Execute<TParams, TResult>(ApiActionAttributes<TParams, TResult> apiAction, TParams @params);
	}
}
