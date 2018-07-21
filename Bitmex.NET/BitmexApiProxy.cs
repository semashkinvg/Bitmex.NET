using Bitmex.NET.Authorization;
using Bitmex.NET.Dtos;
using Bitmex.NET.Logging;
using Bitmex.NET.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bitmex.NET
{
    public class BitmexApiProxy : IBitmexApiProxy
    {
        private static readonly ILog Log = LogProvider.GetCurrentClassLogger();
        private string CurrentHost => $"https://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}";

        private readonly IBitmexAuthorization _bitmexAuthorization;
        private readonly IExpiresTimeProvider _expiresTimeProvider;
        private readonly ISignatureProvider _signatureProvider;

        public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization, IExpiresTimeProvider expiresTimeProvider, ISignatureProvider signatureProvider)
        {
            _bitmexAuthorization = bitmexAuthorization;
            _expiresTimeProvider = expiresTimeProvider;
            _signatureProvider = signatureProvider;
        }
        public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization) : this(bitmexAuthorization, new ExpiresTimeProvider(), new SignatureProvider())
        {
        }

        public async Task<string> Get(string action, IQueryStringParams parameters)
        {
            using (var httpClient = new HttpClient())
            {
                var currentHost = CurrentHost;
                var query = parameters?.ToQueryString() ?? string.Empty;
                query = string.IsNullOrWhiteSpace(query) ? query : "?" + query;
                var url = $"/api/v1/{action}{query}";
                Auth(httpClient, url, HttpMethods.GET);
                Log.Debug($"GET {url}");
                var resp = await httpClient.GetAsync(currentHost + url);
                if (!resp.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
                    throw new BitmexApiException(error);
                }

                var respAsString = await resp.Content.ReadAsStringAsync();
                Log.Debug($"GET {url} resp:{respAsString}");
                return respAsString;
            }
        }

        public async Task<string> Post(string action, IJsonQueryParams parameters)
        {
            using (var httpClient = new HttpClient())
            {
                var url = "/api/v1/" + action;
                var postData = parameters?.ToJson() ?? string.Empty;
                Auth(httpClient, url, HttpMethods.POST, postData);
                Log.Debug($"POST {url}");
                var resp = await httpClient.PostAsync(CurrentHost + url, new StringContent(postData, Encoding.UTF8, "application/json"));
                if (!resp.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
                    throw new BitmexApiException(error);
                }

                var respAsString = await resp.Content.ReadAsStringAsync();
                Log.Debug($"POST {url} resp:{respAsString}");
                return respAsString;
            }
        }
        public async Task<string> Put(string action, IJsonQueryParams parameters)
        {
            using (var httpClient = new HttpClient())
            {
                var url = "/api/v1/" + action;
                var postData = parameters?.ToJson() ?? string.Empty;
                Auth(httpClient, url, HttpMethods.PUT, postData);
                Log.Debug($"PUT {url}");
                var resp = await httpClient.PutAsync(CurrentHost + url, new StringContent(postData, Encoding.UTF8, "application/json"));
                if (!resp.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
                    throw new BitmexApiException(error);
                }

                var respAsString = await resp.Content.ReadAsStringAsync();
                Log.Debug($"PUT {url} resp:{respAsString}");
                return respAsString;
            }
        }
        public async Task<string> Delete(string action, IJsonQueryParams parameters)
        {
            using (var httpClient = new HttpClient())
            {
                var url = "/api/v1/" + action;
                var postData = parameters?.ToJson() ?? string.Empty;
                Auth(httpClient, url, HttpMethods.DELETE, postData);
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = new StringContent(postData, Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(CurrentHost + url)
                };
                var resp = await httpClient.SendAsync(request);
                if (!resp.IsSuccessStatusCode)
                {
                    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
                    throw new BitmexApiException(error);
                }

                var respAsString = await resp.Content.ReadAsStringAsync();
                Log.Debug($"PUT {url} resp:{respAsString}");
                return respAsString;
            }
        }

        private void Auth(HttpClient httpClient, string url, HttpMethods httpMethod, string @params = "")
        {
            var key = _bitmexAuthorization.Key ?? string.Empty;
            var secret = _bitmexAuthorization.Secret ?? string.Empty;
            var expiresTime = _expiresTimeProvider.Get().ToString();
            var signatureString = _signatureProvider.CreateSignature(secret, $"{httpMethod}{url}{expiresTime}{@params}");
            httpClient.DefaultRequestHeaders.Add("api-expires", expiresTime);
            httpClient.DefaultRequestHeaders.Add("api-key", key);
            httpClient.DefaultRequestHeaders.Add("api-signature", signatureString);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
