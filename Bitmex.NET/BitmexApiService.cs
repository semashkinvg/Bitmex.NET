using Bitmex.NET.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Bitmex.NET
{
    public class BitmexApiService : IBitmexApiService
    {
        private readonly IBitmexApiProxy _bitmexApiProxy;

        public BitmexApiService(IBitmexApiProxy bitmexApiProxy)
        {
            _bitmexApiProxy = bitmexApiProxy;
        }

        protected BitmexApiService(IBitmexAuthorization bitmexAuthorization)
        {
            _bitmexApiProxy = new BitmexApiProxy(bitmexAuthorization);
        }

        public async Task<TResult> Execute<TParams, TResult>(ApiActionAttributes<TParams, TResult> apiAction, TParams @params)
        {
            switch (apiAction.Method)
            {
                case HttpMethods.GET:
                    var getQueryParams = @params as IQueryStringParams;
                    return JsonConvert.DeserializeObject<TResult>(
                        await _bitmexApiProxy.Get(apiAction.Action, getQueryParams));
                case HttpMethods.POST:
                    var postQueryParams = @params as IJsonQueryParams;
                    return JsonConvert.DeserializeObject<TResult>(
                        await _bitmexApiProxy.Post(apiAction.Action, postQueryParams));
                case HttpMethods.PUT:
                    var putQueryParams = @params as IJsonQueryParams;
                    return JsonConvert.DeserializeObject<TResult>(
                        await _bitmexApiProxy.Put(apiAction.Action, putQueryParams));
                case HttpMethods.DELETE:
                    var deleteQueryParams = @params as IQueryStringParams;
                    return JsonConvert.DeserializeObject<TResult>(
                        await _bitmexApiProxy.Delete(apiAction.Action, deleteQueryParams));
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static IBitmexApiService CreateDefaultApi(IBitmexAuthorization bitmexAuthorization)
        {
            return new BitmexApiService(bitmexAuthorization);
        }
    }
}
