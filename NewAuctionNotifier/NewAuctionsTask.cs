using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Notifications;

namespace Kopra.NewAuctionNotifier
{
    public sealed class NewAuctionsTask : IBackgroundTask
    {
        private List<Auction> _lastAuctions;
        private readonly RequestGenerator _requestGenerator = new RequestGenerator();
        private List<Auction> _auctions = new List<Auction>();
        private Auction _foundAuction;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            var filterLink = await GetFilter();
            if (filterLink == null)
                return;
            var link = _requestGenerator.FilteredAuction(filterLink);
            var auctions = await AuctionDownloader.GetAuctionsByParameters(link) as List<Auction>;
            _foundAuction = GetNewestAuctions(auctions);
            if (_foundAuction == null)
                return;
            Test(_foundAuction);
            deferral.Complete();
        }

        private void Test(Auction foundAuction)
        {
            SendToastNotification("Title", "Message");
        }

        /// <summary>
        /// Check whether there is any new auction since last check.
        /// </summary>
        /// <param name="auctions"></param>
        /// <returns></returns>
        private Auction GetNewestAuctions(List<Auction> auctions)
        {
            if (_lastAuctions == null)
            {
                _lastAuctions = auctions;
                return _lastAuctions.First();
            }
            foreach (var auction in auctions)
            {
                var newAuction = _lastAuctions.Find(a => a.id == auction.id);
                if (newAuction != null) continue;
                _lastAuctions = auctions;
                return auction;
            }
            return null;
        }

        private async Task<string> GetFilter()
        {
            if (DoesFileExistAsync("BackgroundFilter").Result)
            {
                var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("BackgroundFilter");
                string filterLink;
                using (var reader = new StreamReader(readingStream))
                {
                    filterLink = reader.ReadToEnd();
                }
                return filterLink;
            }
            return null;
        }

        private static void SendToastNotification(string text1, string text2)
        {
            var toastTemplate = ToastTemplateType.ToastText02;
            var toaxtXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var textElements = toaxtXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toaxtXml.CreateTextNode(text1));
            textElements[1].AppendChild(toaxtXml.CreateTextNode(text2));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toaxtXml));
        }

        static async Task<bool> DoesFileExistAsync(string fileName)
        {
            try
            {
                await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
