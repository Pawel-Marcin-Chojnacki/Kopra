﻿using System;
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

        public static void FillLoginData()
        {
            
        }

        public static  async Task<HttpResponseMessage> LoginToService(string text, string password)
        {
            Debug.WriteLine("LoginToService");
            // Sprawdź czy text i password nie są puste.
            if (IsEmailValid(text) && IsPasswordValid(password)) ;
            if (!(text.Contains("@") && password.Length >= 5))
            {
                return null;
            }
            //WTF? Sam nie rozumiem tego co tu wyżej napisł
            // Jeśli nie są, spróbuj się zalogować, zapisz w pamięci telefonu email i hasło.
            httpClient.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue("Kopra","1"));
            var form = new HttpMultipartFormDataContent
            {
                {new HttpStringContent(text), "handle"},
                {new HttpStringContent(password), "passwd"}
            };

            // Add new content to string.
            SaveNewCredentials(text, password);
            response =  httpClient.PostAsync(resourceAddress, form).AsTask(cts.Token).Result;
            return response;
        }

        private static bool IsPasswordValid(string password)
        {
            if (password.Length >= 5) return true;
            else return false;
            //password.Length >= 5 ? true : false;
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
            Debug.WriteLine("SaveNewCredentials");
            SettingsManager credentials = new SettingsManager();
            credentials.Email = email;
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
                return;

            }
            else
            {
                var apiAccessAdress = new Uri("https://kokos.pl/webapiinfo/key");
                response = httpClient.GetAsync(apiAccessAdress).AsTask(cts.Token).Result;
                string key = response.Content.ToString();
                //Debug.WriteLine(key);
                if (key.Contains("klucz to: <b>"))
                { 
                    key = key.Substring(key.IndexOf("klucz to: <b>")+13, 32);
                    Debug.WriteLine(key);
                    credentials.KokosWebApiKey = key;
                }
                else
                {
                    Debug.WriteLine(response.Content);
                }
            }
        }
        
        //!!!!--Does not work.--!!!!//
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
            await Task.Delay(TimeSpan.FromSeconds(1)); //Change for Timestamp
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