using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Notifications;
using Kopra;

namespace Kopra.NewAuctionNotifier
{
    public sealed class NewAuctionsTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            Debug.WriteLine("Jestem w background tasku!");
            var filterLink = await GetFilter();
            //var auctions = AuctionDownloader.GetAuctionsByParameters(new Uri(filterLink));
            Test();
            deferral.Complete();
            //Auction a = new Auction();
        }

        private async Task<string> GetFilter()
        {
            var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("nf");
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


    }
}
