using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace Kopra.Common
{
    public class AuctionDownloader
    {
        public static async Task<ObservableCollection<Auction>> GetAuctionsByParameters(Uri urlAddress)
        {
            var result = new ObservableCollection<Auction>();
            //var request = new RequestGenerator();
            do
            {
                var foundedAuctions = await SendRestRequest(urlAddress);
                urlAddress = InsertNextPageToAddress(urlAddress);
                AddFoundedAuctionsToResult(foundedAuctions, result);
                if (urlAddress.AbsoluteUri.Contains("page=9"))
                {
                    break;
                }
            } while (result.Count < 10);
            return result;
        }

        private static Uri InsertNextPageToAddress(Uri urlAddress)
        {
            var address = urlAddress.AbsoluteUri;
            if (address.Contains("page"))
            {
                int page;
                if (int.TryParse(address.Substring(address.IndexOf("page=") + 5, 1), out page))
                {
                    page++;
                    address = address.Substring(0, address.IndexOf("page")) + "page=" + page.ToString();
                    return new Uri(address);
                }
            }
            else
            {
                address += "&page=1";
                return new Uri(address);
            }
            return null;
        }

        private static void AddFoundedAuctionsToResult(SearchAuctionResult foundedAuctions, ObservableCollection<Auction> result)
        {
            if (foundedAuctions != null)
                foreach (var auction in foundedAuctions.response.auctions.auction)
                {
                    var statusesToCheck = new List<string> {"110", "120", "130", "150", "1500", "1400"};
                    var forbiddenStatus = statusesToCheck.Any(s => auction.status.Equals(s));
                    if (forbiddenStatus)
                        continue;
                    if (result.Count(a=> auction.id == a.id) > 0)
                    {
                        continue;
                    }
                    result.Add(auction);
                }
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