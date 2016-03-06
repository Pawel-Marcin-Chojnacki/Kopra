using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kopra
{
    public class RequestGenerator
    {
        private const string BaseAddress = "https://kokos.pl/webapi/";
        private const string DataType = "type=json";
        private const string Search = "search?";
        private const string RecentAuctions = "get-recent-auctions?";

        /// <summary>
        /// Build Uri to make search for specific auctions.
        /// </summary>
        /// <param name="search">Dictionary with all parameters for search.</param>
        /// <returns>Uri link to API request.</returns>
        public Uri ComposeSearchAuctionQuery(Dictionary<string, string> search)
        {
            string requestAddress = BaseAddress + Search;
            foreach (var item in search)
            {
                requestAddress += item.Key + "=" + item.Value + "&";
            }
            requestAddress += DataType;
            var result = new Uri(requestAddress);
            return result;
        }

        public Uri MostRecentAuctions()
        {
            string requestAddress = BaseAddress + RecentAuctions;
            var sm = new SettingsManager();
            requestAddress += "key=" + sm.KokosWebApiKey + "&";
            requestAddress += DataType + "&";
            requestAddress += "records=3";
            
            var result = new Uri(requestAddress);
            return result;
        }



       
    }
}
