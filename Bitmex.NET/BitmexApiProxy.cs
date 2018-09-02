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

        private readonly IBitmexAuthorization _bitmexAuthorization;
        private readonly IExpiresTimeProvider _expiresTimeProvider;
        private readonly ISignatureProvider _signatureProvider;

        private readonly HttpClient _httpClient;

        public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization, IExpiresTimeProvider expiresTimeProvider, ISignatureProvider signatureProvider)
        {
            _bitmexAuthorization = bitmexAuthorization;
            _expiresTimeProvider = expiresTimeProvider;
            _signatureProvider = signatureProvider;

            _httpClient = new HttpClient { BaseAddress = new Uri($"https://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}") };

            _httpClient.DefaultRequestHeaders.Add("api-key", _bitmexAuthorization.Key ?? string.Empty);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/javascript"));
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
        }

        public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization) : this(bitmexAuthorization, new ExpiresTimeProvider(), new SignatureProvider())
        {
        }

        public Task<string> Get(string action, IQueryStringParams parameters)
        {
            var query = parameters?.ToQueryString() ?? string.Empty;
            var request = new HttpRequestMessage(HttpMethod.Get, GetUrl(action) + (string.IsNullOrWhiteSpace(query) ? string.Empty : "?" + query));

            return SendAndGetResponseAsync(request);
        }

        public Task<string> Delete(string action, IQueryStringParams parameters)
        {
            var query = parameters?.ToQueryString() ?? string.Empty;
            var request = new HttpRequestMessage(HttpMethod.Delete, GetUrl(action) + (string.IsNullOrWhiteSpace(query) ? string.Empty : "?" + query));

            return SendAndGetResponseAsync(request);
        }

        public Task<string> Post(string action, IJsonQueryParams parameters) => SendAndGetResponseAsync(HttpMethod.Post, action, parameters);

        public Task<string> Put(string action, IJsonQueryParams parameters) => SendAndGetResponseAsync(HttpMethod.Put, action, parameters);


        private Task<string> SendAndGetResponseAsync(HttpMethod method, string action, IJsonQueryParams parameters)
        {
            var content = parameters?.ToJson() ?? string.Empty;
            var url = GetUrl(action);
            Log.Debug($"{action} sending content:{content}");
            var request = new HttpRequestMessage(method, url)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };

            return SendAndGetResponseAsync(request, content);
        }

        private async Task<string> SendAndGetResponseAsync(HttpRequestMessage request, string @params = null)
        {
            Sign(request, @params);

            Log.Debug($"{request.Method} {request.RequestUri}");

            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            Log.Debug($"{request.Method} {request.RequestUri.PathAndQuery} {(response.IsSuccessStatusCode ? "resp" : "errorResp")}:{responseString}");

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    throw new BitmexApiException(JsonConvert.DeserializeObject<BitmexApiError>(responseString));
                }
                catch (JsonReaderException)
                {
                    throw new BitmexApiException(responseString);
                }
            }

            return responseString;
        }

        private void Sign(HttpRequestMessage request, string @params)
        {
            request.Headers.Add("api-expires", _expiresTimeProvider.Get().ToString());
            request.Headers.Add("api-signature", _signatureProvider.CreateSignature(_bitmexAuthorization.Secret ?? string.Empty,
                $"{request.Method}{request.RequestUri}{_expiresTimeProvider.Get().ToString()}{@params}"));
        }

        private static string GetUrl(string action) => "/api/v1/" + action;
    }
}
