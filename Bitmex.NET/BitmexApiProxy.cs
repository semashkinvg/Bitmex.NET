using Bitmex.NET.Dtos;
using Bitmex.NET.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bitmex.NET
{
	public class BitmexApiProxy : IBitmexApiProxy
	{
		private static long _lastNonce = 0;
		private readonly IDictionary<BitmexEnvironment, string> _environments = new Dictionary<BitmexEnvironment, string>
		{
			{BitmexEnvironment.Test, "https://testnet.bitmex.com"},
			{BitmexEnvironment.Prod, "https://www.bitmex.com"}
		};

		private string CurrentUrl => _environments[_bitmexAuthorization.BitmexEnvironment];

		private readonly IBitmexAuthorization _bitmexAuthorization;

		public BitmexApiProxy(IBitmexAuthorization bitmexAuthorization)
		{
			_bitmexAuthorization = bitmexAuthorization;
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
					var error = await resp.Content.ReadAsStringAsync();
					throw new Exception(error);
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
					var error = await resp.Content.ReadAsStringAsync();
					throw new Exception(error);
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
					var error = await resp.Content.ReadAsStringAsync();
					throw new Exception(error);
				}

				return await resp.Content.ReadAsStringAsync();
			}
		}

		private void Auth(HttpClient httpClient, string url, HttpMethods httpMethod, string @params = "")
		{
			var key = _bitmexAuthorization.Key ?? string.Empty;
			var secret = _bitmexAuthorization.Secret ?? string.Empty;
			var nonce = GetNonce().ToString();
			var message = $"{httpMethod}{url}{nonce}{@params}";
			var signatureBytes = hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
			var signatureString = ByteArrayToString(signatureBytes);
			httpClient.DefaultRequestHeaders.Add("api-nonce", nonce);
			httpClient.DefaultRequestHeaders.Add("api-key", key);
			httpClient.DefaultRequestHeaders.Add("api-signature", signatureString);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		private byte[] hmacsha256(byte[] keyByte, byte[] messageBytes)
		{
			using (var hash = new HMACSHA256(keyByte))
			{
				return hash.ComputeHash(messageBytes);
			}
		}

		public static string ByteArrayToString(byte[] ba)
		{
			var hex = new StringBuilder(ba.Length * 2);
			foreach (var b in ba)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}

		private long GetNonce()
		{
			var yearBegin = new DateTime(1990, 1, 1);
			var newNonce = DateTime.UtcNow.Ticks - yearBegin.Ticks;
			if (_lastNonce < newNonce)
			{
				Interlocked.Exchange(ref _lastNonce, newNonce);
				return _lastNonce;
			}

			Interlocked.Increment(ref _lastNonce);
			return _lastNonce;
		}
	}
}
