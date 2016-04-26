using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Newtonsoft.Json;

namespace Kopra
{
    public static class ConnectionManager
    {
        //private static UserCredentials user;
        public static HttpClient HttpClient = new HttpClient();
        private static CancellationTokenSource _cts = new CancellationTokenSource();
        private const string LoginAddress = "https://kokos.pl/uzytkownik/dane-osobowe";
        private static readonly Uri ResourceAddress = new Uri(LoginAddress);
        private static HttpResponseMessage _response;

        public static  async Task<HttpResponseMessage> LoginToService(string text, string password)
        {
            Debug.WriteLine("LoginToService");
            if (!(IsEmailValid(text) && IsPasswordValid(password)))
                return null;
            if (!(text.Contains("@") && password.Length >= 5))
                return null;
            HttpClient.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue("Kopra","1"));
            var form = new HttpMultipartFormDataContent
            {
                {new HttpStringContent(text), "handle"},
                {new HttpStringContent(password), "passwd"}
            };

            // Add new content to string.
            SaveNewCredentials(text, password);
            _response =  HttpClient.PostAsync(ResourceAddress, form).AsTask(_cts.Token).Result;
            return _response;
        }

        private static bool IsPasswordValid(string password)
        {
            return password.Length >= 5;
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
            //Debug.WriteLine("SaveNewCredentials");
            SettingsManager credentials = new SettingsManager {Email = email};
            Debug.WriteLine(credentials.Email);
            credentials.Password = password;
        }

        public static void GetWebApiKeyFromService()
        {
            Debug.WriteLine("GetWebAPIKeyFromService");
            var credentials = new SettingsManager();
            if (credentials.KokosWebApiKey != null)
            {   
                Debug.WriteLine("Kokos webapiKEy " + credentials.KokosWebApiKey);
            }
            else
            {
                var apiAccessAdress = new Uri("https://kokos.pl/webapiinfo/key");
                _response = HttpClient.GetAsync(apiAccessAdress).AsTask(_cts.Token).Result;
                string key = _response.Content.ToString();
                Debug.WriteLine(key);
                if (key.Contains("klucz to: <strong>"))
                { 
                    key = key.Substring(key.IndexOf("klucz to: <strong>")+18, 32);
                    Debug.WriteLine(key);
                    credentials.KokosWebApiKey = key;
                }
                else
                {
                    Debug.WriteLine(_response.Content);
                }
            }
        }
        
       
        public static void GenerateApiKeyFromService()
        {
            Uri apiGeneratorAddress = new Uri("https://kokos.pl/webapiinfo/key/webapiinfo/generate-key");
            HttpMultipartFormDataContent form = new HttpMultipartFormDataContent();
            // response = await httpClient.GetAsync(apiGeneratorAddress).AsTask(cts.Token);
            //Debug.WriteLine(_response.Content);
            GetWebApiKeyFromService();
        }

        public static async Task<SearchAuctionResult> SendRestRequest(Uri address)
        {
            await Task.Delay(TimeSpan.FromSeconds(1)); //Change for Timestamp
            Debug.WriteLine("SendRESTRequest");
            _response = await HttpClient.GetAsync(address).AsTask(_cts.Token);
            var auctionsJson = new SearchAuctionResult();
            Debug.WriteLine(address);
            Debug.WriteLine(_response.Content);
            try
            {
                auctionsJson = JsonConvert.DeserializeObject<SearchAuctionResult>(_response.Content.ToString());
            }
            catch (Exception)
            {
                return null;
            }
            return auctionsJson;
        }

    }
}
