using System;
using System.Collections.Generic;
using System.Linq;
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
        private const string Records = "records=";

        /// <summary>
        /// Composes new query for searching. 
        /// </summary>
        /// <param name="search">Dictionary with parameters for query.</param>
        /// <returns>URI with API request.</returns>
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

        /// <summary>
        /// Composes request to get 3 most recent auctions.
        /// </summary>
        /// <returns>API query to get most recent auctions.</returns>
        public Uri MostRecentAuctions()
        {
            var requestAddress = BaseAddress + RecentAuctions;
            var sm = new SettingsManager();
            requestAddress += "key=" + sm.KokosWebApiKey + "&";
            requestAddress += DataType + "&";
            requestAddress += Records + "3";
            var result = new Uri(requestAddress);
            return result;
        }



       
    }
}
