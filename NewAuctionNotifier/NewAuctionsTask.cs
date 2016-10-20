using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Notifications;
using Kopra;
using Kopra.Model.Auction;

namespace Kopra.NewAuctionNotifier
{
    public sealed class NewAuctionsTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            Debug.WriteLine("Jestem w background tasku!");
 
            //dataService.GetAuctionsByParameters(new Uri(filterLink));
            Test();
            deferral.Complete();
            Auction a = new Auction();
        }

        private async Task<string> GetFilter()
        {
            var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("NotificationFilterForBackgroundTask");
            string filterLink;
            using (var reader = new StreamReader(readingStream))
            {
                filterLink = reader.ReadToEnd();
            }
            return filterLink;
        }

        private static void Test()
        {
            SendToastNotification("Jestem tostem", "Bardzo serowy tost dotarł");
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

        //public async Task<ObservableCollection<Auction>> GetAuctionsByParameters(Uri urlAddress)
        //{
        //    var result = new ObservableCollection<Auction>();
        //    var request = new RequestGenerator();
        //    var foundedAuctions = await KokosConnectionManager.SendRestRequest(urlAddress);
        //    if (foundedAuctions != null)
        //        foreach (var auction in foundedAuctions.response.auctions.auction)
        //        {
        //            var statusesToCheck = new List<string> { "110", "120", "130", "150", "1500", "1400" };
        //            var forbiddenStatus = statusesToCheck.Any(s => auction.status.Equals(s));
        //            if (forbiddenStatus)
        //                continue;
        //            result.Add(auction);
        //        }
        //    return result;
        //}
    }
}
