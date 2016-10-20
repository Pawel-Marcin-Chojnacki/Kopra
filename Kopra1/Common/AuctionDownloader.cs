using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Kopra.Model.Auction;
using Newtonsoft.Json;

namespace Kopra.Common
{
    public class AuctionDownloader
    {
        public static async Task<ObservableCollection<Auction>> GetAuctionsByParameters(Uri urlAddress)
        {
            var result = new ObservableCollection<Auction>();
            //var request = new RequestGenerator();
            var foundedAuctions = await SendRestRequest(urlAddress);
            if (foundedAuctions != null)
                foreach (var auction in foundedAuctions.response.auctions.auction)
                {
                    var statusesToCheck = new List<string> {"110", "120", "130", "150", "1500", "1400" };
                    var forbiddenStatus = statusesToCheck.Any(s => auction.status.Equals(s));
                    if (forbiddenStatus)
                        continue;
                    result.Add(auction);
                }
            return result;
        }
        public static HttpClient HttpClient = new HttpClient();
        private static CancellationTokenSource _cts = new CancellationTokenSource();
        private static HttpResponseMessage _response;

        public static async Task<SearchAuctionResult> SendRestRequest(Uri address)
        {
            _response = await HttpClient.GetAsync(address).AsTask(_cts.Token);
            SearchAuctionResult auctionsJson;
            //var acute = new Regex(@"&oacute;");
            //var response = acute.Replace(_response.Content.ToString(), @"ó");
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