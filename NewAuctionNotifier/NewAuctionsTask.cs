using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace Kopra.NewAuctionNotifier
{
    public sealed class NewAuctionsTask : IBackgroundTask
    {
        private readonly RequestGenerator _requestGenerator = new RequestGenerator();
        private List<Auction> _auctions = new List<Auction>();
        private Auction _foundAuction;
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();
            var filterLink = await GetFilter();
            if (filterLink == null) return;
            Uri link = _requestGenerator.FilteredAuction(filterLink);
            var auctions = await AuctionDownloader.GetAuctionsByParameters(link) as List<Auction>;
            _foundAuction = GetNewestAuctions(auctions);
            if (_foundAuction == null)
                return;
            Test(_foundAuction);
            deferral.Complete();
        }

        private void Test(Auction foundAuction)
        {
            if (foundAuction.value.Contains(".00"))
            {
                foundAuction.value = foundAuction.value.Substring(0, foundAuction.value.IndexOf('.'));
            }
            var detailedMessage = foundAuction.user + ", " + foundAuction.value + "zł, " + foundAuction.percent;
            SendToastNotification(foundAuction.title, detailedMessage, foundAuction.id);
        }

        /// <summary>
        /// Check whether there is any new auction since last check.
        /// </summary>
        /// <param name="auctions"></param>
        /// <returns></returns>
        private Auction GetNewestAuctions(List<Auction> auctions)
        {
            var lastFoundAuctionId = (string)Windows.Storage.ApplicationData.Current.LocalSettings.Values["AuctionId"];
            if (lastFoundAuctionId == null)
            { // tutaj dodaj zapisywanie id ostatnio znalezionej aukcji do localstorage.
                var auction = auctions.First();
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["AuctionId"] = auction.id;
                return auctions.First();
            }
            else if (auctions.First().id == lastFoundAuctionId)
            {
                return null;
            }
            else
            {
                Windows.Storage.ApplicationData.Current.LocalSettings.Values["AuctionId"] = auctions.First().id;
                return auctions.First();
            }
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

        private static void SendToastNotification(string text1, string text2, string id)
        {
            var toastTemplate = ToastTemplateType.ToastText02;
            var toaxtXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var navigationUriString = "/SearchResultPage.xaml";
            var textElements = toaxtXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toaxtXml.CreateTextNode(text1));
            textElements[1].AppendChild(toaxtXml.CreateTextNode(text2));
            IXmlNode toastNode = toaxtXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("launch","!"+id);
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
