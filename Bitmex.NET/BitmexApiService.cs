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

        public async Task<BitmexApiResult<TResult>> Execute<TParams, TResult>(ApiActionAttributes<TParams, TResult> apiAction, TParams @params)
        {
            switch (apiAction.Method)
            {
                case HttpMethods.GET:
                    {
                        var getQueryParams = @params as IQueryStringParams;
                        var serializedResult = await _bitmexApiProxy.Get(apiAction.Action, getQueryParams);
                        var deserializedResult = JsonConvert.DeserializeObject<TResult>(serializedResult.Result);
                        return serializedResult.ToResultType<TResult>(deserializedResult);
                    }
                case HttpMethods.POST:
                    {
                        var postQueryParams = @params as IJsonQueryParams;
                        var serializedResult = await _bitmexApiProxy.Post(apiAction.Action, postQueryParams);
                        var deserializedResult = JsonConvert.DeserializeObject<TResult>(serializedResult.Result);
                        return serializedResult.ToResultType<TResult>(deserializedResult);
                    }
                case HttpMethods.PUT:
                    {
                        var putQueryParams = @params as IJsonQueryParams;
                        var serializedResult = await _bitmexApiProxy.Put(apiAction.Action, putQueryParams);
                        var deserializedResult = JsonConvert.DeserializeObject<TResult>(serializedResult.Result);
                        return serializedResult.ToResultType<TResult>(deserializedResult);
                    }
                case HttpMethods.DELETE:
                    {
                        var deleteQueryParams = @params as IQueryStringParams;
                        var serializedResult = await _bitmexApiProxy.Delete(apiAction.Action, deleteQueryParams);
                        var deserializedResult = JsonConvert.DeserializeObject<TResult>(serializedResult.Result);
                        return serializedResult.ToResultType<TResult>(deserializedResult);
                    }
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
