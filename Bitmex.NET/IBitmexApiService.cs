using System.Threading.Tasks;

namespace Bitmex.NET
{
	public interface IBitmexApiService
	{
		Task<TResult> Execute<TParams, TResult>(ApiActionAttributes<TParams, TResult> apiAction, TParams @params);
	}
}
