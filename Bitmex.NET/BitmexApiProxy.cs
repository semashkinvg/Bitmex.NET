using Bitmex.NET.Authorization;
using Bitmex.NET.Dtos;
using Bitmex.NET.Logging;
using Bitmex.NET.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
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
        private readonly DateTime _epochTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

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

        public Task<BitmexApiResult<string>> Get(string action, IQueryStringParams parameters)
        {
            var query = parameters?.ToQueryString() ?? string.Empty;
            var request = new HttpRequestMessage(HttpMethod.Get, GetUrl(action) + (string.IsNullOrWhiteSpace(query) ? string.Empty : "?" + query));

            CorrectUri(request);
            
            return SendAndGetResponseAsync(request);
        }

        public Task<BitmexApiResult<string>> Delete(string action, IQueryStringParams parameters)
        {
            var query = parameters?.ToQueryString() ?? string.Empty;
            var request = new HttpRequestMessage(HttpMethod.Delete, GetUrl(action) + (string.IsNullOrWhiteSpace(query) ? string.Empty : "?" + query));

            CorrectUri(request);
            
            return SendAndGetResponseAsync(request);
        }

        public Task<BitmexApiResult<string>> Post(string action, IJsonQueryParams parameters) => SendAndGetResponseAsync(HttpMethod.Post, action, parameters);

        public Task<BitmexApiResult<string>> Put(string action, IJsonQueryParams parameters) => SendAndGetResponseAsync(HttpMethod.Put, action, parameters);


        private Task<BitmexApiResult<string>> SendAndGetResponseAsync(HttpMethod method, string action, IJsonQueryParams parameters)
        {
            var content = parameters?.ToJson() ?? string.Empty;
            var url = GetUrl(action);
            Log.Debug($"{action} sending content:{content}");
            var request = new HttpRequestMessage(method, url)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
            
            CorrectUri(request);

            return SendAndGetResponseAsync(request, content);
        }

        private async Task<BitmexApiResult<string>> SendAndGetResponseAsync(HttpRequestMessage request, string @params = null)
        {
            Sign(request, @params);

            Log.Debug($"{request.Method} {request.RequestUri}");

            var response = await _httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            Log.Debug($"{request.Method} {request.RequestUri.PathAndQuery} {(response.IsSuccessStatusCode ? "resp" : "errorResp")}:{responseString}");

            int rateLimitLimit = default, rateLimitRemaining = default;
            DateTime rateLimitReset = default;

            if (response.Headers.TryGetValues("x-ratelimit-limit", out var ratelimitlimit) && ratelimitlimit.Any())
                rateLimitLimit = int.Parse(ratelimitlimit.First());
            if (response.Headers.TryGetValues("x-ratelimit-remaining", out var ratelimitremaining) && ratelimitremaining.Any())
                rateLimitRemaining = int.Parse(ratelimitremaining.First());
            if (response.Headers.TryGetValues("x-ratelimit-reset", out var ratelimitreset) && ratelimitreset.Any())
                rateLimitReset = _epochTime.AddSeconds(long.Parse(ratelimitreset.First()));

            Log.Debug($"{request.Method} {request.RequestUri.PathAndQuery} x-ratelimit-limit:{rateLimitLimit} x-ratelimit-remaining:{rateLimitRemaining} x-ratelimit-reset:{rateLimitReset}");

            if (!response.IsSuccessStatusCode)
            {
                int? retryAfterSeconds = null;
                if ((int) response.StatusCode == 429 && response.Headers.RetryAfter?.Delta != null)
                {
                    retryAfterSeconds = (int)response.Headers.RetryAfter.Delta.Value.TotalSeconds;
                }

                try
                {
                    throw new BitmexApiException((int)response.StatusCode, JsonConvert.DeserializeObject<BitmexApiError>(responseString))
                    {
                        RetryAfterSeconds = retryAfterSeconds,
                    };
                }
                catch (JsonReaderException)
                {
                    throw new BitmexApiException((int)response.StatusCode, responseString)
                    {
                        RetryAfterSeconds = retryAfterSeconds,
                    };
                }
            }

            return new BitmexApiResult<string>(responseString, rateLimitLimit, rateLimitRemaining, rateLimitReset);
        }

        private void Sign(HttpRequestMessage request, string @params)
        {
            request.Headers.Add("api-expires", _expiresTimeProvider.Get().ToString());
            request.Headers.Add("api-signature", _signatureProvider.CreateSignature(_bitmexAuthorization.Secret ?? string.Empty,
                $"{request.Method}{request.RequestUri}{_expiresTimeProvider.Get().ToString()}{@params}"));
        }

        private static string GetUrl(string action) => "/api/v1/" + action;
        
        private static void CorrectUri(HttpRequestMessage request)
        {
            request.RequestUri = new Uri(request.RequestUri.OriginalString, UriKind.Relative);
        }
    }
}
