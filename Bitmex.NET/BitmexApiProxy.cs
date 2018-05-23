using Bitmex.NET.Authorization;
using Bitmex.NET.Dtos;
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
		private string CurrentUrl => $"https://{Environments.Values[_bitmexAuthorization.BitmexEnvironment]}";

		private readonly IBitmexAuthorization _bitmexAuthorization;
		private readonly INonceProvider _nonceProvider;
		private readonly ISignatureProvider _signatureProvider;

		public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization, INonceProvider nonceProvider, ISignatureProvider signatureProvider)
		{
			_bitmexAuthorization = bitmexAuthorization;
			_nonceProvider = nonceProvider;
			_signatureProvider = signatureProvider;
		}
		public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization) : this(bitmexAuthorization, new NonceProvider(), new SignatureProvider())
		{
		}

		public async Task<string> Get(string action, IQueryStringParams parameters)
		{
			using (var httpClient = new HttpClient())
			{
				var query = parameters?.ToQueryString() ?? string.Empty;
				query = string.IsNullOrWhiteSpace(query) ? query : "?" + query;
				var url = $"/api/v1/{action}{query}";
				Auth(httpClient, url, HttpMethods.GET);
				var resp = await httpClient.GetAsync(CurrentUrl + url);
				if (!resp.IsSuccessStatusCode)
				{
					var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
					throw new BitmexApiException(error);
				}

				return await resp.Content.ReadAsStringAsync();
			}
		}

		public async Task<string> Post(string action, IJsonQueryParams parameters)
		{
			using (var httpClient = new HttpClient())
			{
				var url = "/api/v1/" + action;
				var postData = parameters?.ToJson() ?? string.Empty;
				Auth(httpClient, url, HttpMethods.POST, postData);
				var resp = await httpClient.PostAsync(CurrentUrl + url, new StringContent(postData, Encoding.UTF8, "application/json"));
				if (!resp.IsSuccessStatusCode)
				{
				    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
				    throw new BitmexApiException(error);
                }

				return await resp.Content.ReadAsStringAsync();
			}
		}
		public async Task<string> Put(string action, IJsonQueryParams parameters)
		{
			using (var httpClient = new HttpClient())
			{
				var url = "/api/v1/" + action;
				var postData = parameters?.ToJson() ?? string.Empty;
				Auth(httpClient, url, HttpMethods.PUT, postData);
				var resp = await httpClient.PutAsync(CurrentUrl + url, new StringContent(postData, Encoding.UTF8, "application/json"));
				if (!resp.IsSuccessStatusCode)
				{
				    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
				    throw new BitmexApiException(error);
                }

				return await resp.Content.ReadAsStringAsync();
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
					RequestUri = new Uri(CurrentUrl + url)
				};
				var resp = await httpClient.SendAsync(request);
				if (!resp.IsSuccessStatusCode)
				{
				    var error = JsonConvert.DeserializeObject<BitmexApiError>(await resp.Content.ReadAsStringAsync());
				    throw new BitmexApiException(error);
                }

				return await resp.Content.ReadAsStringAsync();
			}
		}

		private void Auth(HttpClient httpClient, string url, HttpMethods httpMethod, string @params = "")
		{
			var key = _bitmexAuthorization.Key ?? string.Empty;
			var secret = _bitmexAuthorization.Secret ?? string.Empty;
			var nonce = _nonceProvider.GetNonce().ToString();
			var signatureString = _signatureProvider.CreateSignature(secret, $"{httpMethod}{url}{nonce}{@params}");
			httpClient.DefaultRequestHeaders.Add("api-nonce", nonce);
			httpClient.DefaultRequestHeaders.Add("api-key", key);
			httpClient.DefaultRequestHeaders.Add("api-signature", signatureString);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}
