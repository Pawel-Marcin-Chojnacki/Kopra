using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Notifications;
using Windows.Web.Http;
using Newtonsoft.Json;

namespace Kopra.NewAuctionNotifier
{
    public sealed class AuctionDownloader
    {
        public static IAsyncOperation<IList<Auction>> GetAuctionsByParameters(Uri urlAddress)
        {
            return AuctionDownloader.GetAuctionsByParametersHelper(urlAddress).AsAsyncOperation();
        }

        private static async Task<IList<Auction>> GetAuctionsByParametersHelper(Uri urlAddress)
        {
            var result = new List<Auction>();
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

        private static HttpClient HttpClient = new HttpClient();
        private static CancellationTokenSource _cts = new CancellationTokenSource();
        private static HttpResponseMessage _response;

        public static IAsyncOperation<SearchAuctionResult> SendRestRequest(Uri address)
        {
            return SendRestRequestHelper(address).AsAsyncOperation();
        }

        private static async Task<SearchAuctionResult> SendRestRequestHelper(Uri address)
        {
            _response = await HttpClient.GetAsync(address).AsTask(_cts.Token);
            SearchAuctionResult auctionsJson;
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