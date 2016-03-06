using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace Kopra
{
    public static class KokosConnectionManager
    {
        //private static UserCredentials user;
        public static HttpClient httpClient = new HttpClient();
        private static CancellationTokenSource cts = new CancellationTokenSource();
        private const string LoginAddress = "https://kokos.pl/uzytkownik/dane-osobowe";
        private static Uri resourceAddress = new Uri(LoginAddress);
        private static HttpResponseMessage response;

        //public static void FillLoginData()
        //{
            
        //}

        public static  async Task<HttpResponseMessage> LoginToService(string text, string password)
        {
            Debug.WriteLine("LoginToService");
            httpClient.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue("Kopra","1"));
            var form = new HttpMultipartFormDataContent
            {
                {
                    new HttpStringContent(text), "handle"
                },
                {
                    new HttpStringContent(password), "passwd"
                }
            };

            SaveNewCredentials(text, password);
            response = await httpClient.PostAsync(resourceAddress, form).AsTask(cts.Token);
            return response;
        }

        //private static bool IsPasswordValid(string password)
        //{
        //    return password.Length >= 5;
        //}

        ///// <summary>
        ///// Naive method to check basic correctness of email address.
        ///// </summary>
        ///// <param name="email">String to check if it's an correct form of email address.</param>
        ///// <returns>Bool, true if string contains @ sign.</returns>
        //private static bool IsEmailValid(string email)
        //{
        //    return email.Contains("@");
        //}

        private static void SaveNewCredentials(string email, string password)
        {
            //Debug.WriteLine("SaveNewCredentials");
            SettingsManager credentials = new SettingsManager();
            credentials.Email = email;
            //Debug.WriteLine(credentials.Email);
            credentials.Password = password;
        }

        public static void GetWebApiKeyFromService()
        {
            //Debug.WriteLine("GetWebAPIKeyFromService");
            var credentials = new SettingsManager();
            if (credentials.KokosWebApiKey != null)
            {
                //Debug.WriteLine("Kokos webapiKEy " + credentials.KokosWebApiKey);
                return;
            }
            else
            {
                var apiAccessAdress = new Uri("https://kokos.pl/webapiinfo/key");
                response = httpClient.GetAsync(apiAccessAdress).AsTask(cts.Token).Result;
                string key = response.Content.ToString();
                //Debug.WriteLine(key);
                if (key.Contains("klucz to: <strong>"))
                { 
                    key = key.Substring(key.IndexOf("klucz to: <strong>")+18, 32);
                    Debug.WriteLine(key);
                    credentials.KokosWebApiKey = key;
                }
                else
                {
                    Debug.WriteLine(response.Content);
                }
            }
        }
        
       
        /// <summary>
        /// If key is not present at runtime, generate new key.
        /// </summary>
        public static void GenerateApiKeyFromService()
        {
            Uri apiGeneratorAddress = new Uri("https://kokos.pl/webapiinfo/key/webapiinfo/generate-key");
            HttpMultipartFormDataContent form = new HttpMultipartFormDataContent();
            // response = await httpClient.GetAsync(apiGeneratorAddress).AsTask(cts.Token);
            Debug.WriteLine(response.Content);
            GetWebApiKeyFromService();
        }

        public static async Task<SearchAuctionResult> SendRestRequest(Uri address)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            Debug.WriteLine("SendRESTRequest");
            response = await httpClient.GetAsync(address).AsTask(cts.Token);
            var auctionsJSON = new SearchAuctionResult();
            Debug.WriteLine(address);
            Debug.WriteLine(response.Content);
            try
            {
                auctionsJSON = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchAuctionResult>(response.Content.ToString());
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return auctionsJSON;
        }

    }
}
