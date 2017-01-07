using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Kopra.Model;
using Kopra.Model.Auction;
using Newtonsoft.Json;

namespace Kopra
{
	public static class KokosConnectionManager
	{
		//private static UserCredentials user;
		public static HttpClient HttpClient = new HttpClient();
		private static CancellationTokenSource _cts = new CancellationTokenSource();
		private const string LoginAddress = "https://kokos.pl/uzytkownik/dane-osobowe";
		private static readonly Uri _resourceAddress = new Uri(LoginAddress);
		private static HttpResponseMessage _response;
		private static SettingsManager settingsManager = new SettingsManager();

		public static async Task<HttpResponseMessage> LoginToService(string text, string password)
		{
			HttpClient.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue("Kopra","1"));
			var form = new HttpMultipartFormDataContent
			{
				{new HttpStringContent(text), "handle"},
				{new HttpStringContent(password), "passwd"}
			};

			// Add new content to string.
			SaveNewCredentials(text, password);
			_response =  HttpClient.PostAsync(_resourceAddress, form).AsTask(_cts.Token).Result;
			return _response;
		}

		private static bool IsPasswordValid(string password)
		{
			if (password.Length >= 5) return true;
			return false;
		}

		/// <summary>
		/// Naive method to check basic correctness of email address.
		/// </summary>
		/// <param name="email">String to check if it's an correct form of email address.</param>
		/// <returns>Bool, true if string contains @ sign.</returns>
		private static bool IsEmailValid(string email)
		{
			return email.Contains("@");
		}

		private static void SaveNewCredentials(string email, string password)
		{
			var credentials = new SettingsManager {Email = email};
			credentials.Password = password;
		}

		public static void GetWebApiKeyFromService()
		{
			var credentials = new SettingsManager();
			if (!string.IsNullOrWhiteSpace(credentials.KokosWebApiKey) && !string.IsNullOrWhiteSpace(credentials.KokosWebApiValid))
			{
			}
			else
			{
				var apiAccessAdress = new Uri("https://kokos.pl/webapiinfo/key");
				_response = HttpClient.GetAsync(apiAccessAdress).AsTask(_cts.Token).Result;
				var key = _response.Content.ToString();
				if (key.Contains("klucz to: <strong>"))
				{
					key = key.Substring(key.IndexOf("klucz to: <strong>")+18, 32);
					credentials.KokosWebApiKey = key;
					var valid = _response.Content.ToString();
					valid = valid.Substring(valid.IndexOf("Data waÅ¼noÅci: <strong>")+25, 19);
					credentials.KokosWebApiValid = valid;
				}
			}
		}

		public static async Task<ApiKeyGenerate> GenerateApiKeyFromService()
		{
			var result = new ApiKeyGenerate();
			var apiGeneratorAddress = new Uri("https://kokos.pl/webapiinfo/generate-key");
			var form = new HttpMultipartFormDataContent();
			form.Add(new HttpFormUrlEncodedContent(new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("","")}));
			var response = HttpClient.PostAsync(apiGeneratorAddress, form).AsTask(_cts.Token).Result;
			await Task.Delay(10000);
			var apiAccessAdress = new Uri("https://kokos.pl/webapiinfo/key");
			_response = HttpClient.GetAsync(apiAccessAdress).AsTask(_cts.Token).Result;
			var key = _response.Content.ToString();
			var credentials = new SettingsManager();
			if (key.Contains("klucz to: <strong>"))
			{
				key = key.Substring(key.IndexOf("klucz to: <strong>") + 18, 32);
				credentials.KokosWebApiKey = key;

				var valid = _response.Content.ToString();
				valid = valid.Substring(valid.IndexOf("Data waÅ¼noÅci: <strong>") + 25, 19);

				credentials.KokosWebApiValid = valid;
				result.ValidTime = valid;
				result.Message = "Wygenerowano nowy klucz, będzie ważny przez rok!\n";
			}
			//GetWebApiKeyFromService();
			if (result.ValidTime != null)
			{
				return result;
				//return SetApiKeyMessage(, result.ValidTime);
			}
			else
			{
				result.ValidTime = "Błąd pobierania daty.";
				result.Message = "Nie można wygenerować klucza z nieznanej przyczyny!\n";
				return result;
			}
		}

		private static ApiKeyGenerate SetApiKeyMessage(string message, string date)
		{
			var result = new ApiKeyGenerate
			{
				Message = message
				, ValidTime = date
			};
			return result;
		}

		public static async Task<SearchAuctionResult> SendRestRequest(Uri address)
		{
			await Task.Delay(TimeSpan.FromSeconds(1)); //Change for Timestamp
			_response = await HttpClient.GetAsync(address).AsTask(_cts.Token);
			var auctionsJson = new SearchAuctionResult();
			var acute = new Regex(@"&oacute;");
			var response = acute.Replace(_response.Content.ToString(), @"ó");
			try
			{
				auctionsJson = JsonConvert.DeserializeObject<SearchAuctionResult>(response);
			}
			catch (Exception exception)
			{
				return null;
			}
			return auctionsJson;
		}

		public static async Task<Model.Auction.Auction> GetAuctionDataRequest(Uri address)
		{
			//await Task.Delay(TimeSpan.FromSeconds(1));
			_response = await HttpClient.GetAsync(address).AsTask(_cts.Token);
			var auctionJson = new GetAuctionDataRoot();
			var acute = new Regex(@"&oacute;");
			var response = acute.Replace(_response.Content.ToString(), @"ó");
			try
			{
				auctionJson = JsonConvert.DeserializeObject<GetAuctionDataRoot>(response, new JsonSerializerSettings
				{
					MissingMemberHandling = MissingMemberHandling.Ignore,
					NullValueHandling = NullValueHandling.Ignore,
				});
			}
			catch (Exception exception)
			{
				throw exception;
			}
			return auctionJson.response.auction;
		}

		public static async Task<string> GetWebSource(string address)
		{
			var location = new Uri(address);
			var source = await HttpClient.GetAsync(location).AsTask(_cts.Token);
			return source.Content.ToString();
		}
	}
}
