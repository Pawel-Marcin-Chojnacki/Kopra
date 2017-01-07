using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Kopra.NewAuctionNotifier
{
    /// <summary>
    /// Class responsible for generating Web API url's for REST server.
    /// </summary>
    internal sealed class  RequestGenerator
    {
        private const string BaseAddress = "https://kokos.pl/webapi/";
        private const string DataType = "&type=json";
        private const string Search = "search?";
        private const string RecentAuctions = "get-recent-auctions?";
	    private const string AuctionData = "get-auction-data?";
	    private const string Comments = "comments=1";
		private const string Records = "records=";
        private const string Key = "key=";
	    private const string Id = "id=";
	    private const string Type = "type=";

		private const string SearchQuery = BaseAddress + Search + Key;

        public Uri FilteredAuction(string filter)
        {
            var webRequest = new StringBuilder();
            webRequest.Append(BaseAddress);
            webRequest.Append(Search);
            webRequest.Append("&");
            var sm = new SettingsManager();
            webRequest.Append(Key + sm.KokosWebApiKey);
            webRequest.Append(filter);
            webRequest.Append(DataType);
            return new Uri(webRequest.ToString());
        }

        /// <summary>
        /// Composes new query for searching.
        /// </summary>
        /// <param name="search">Dictionary with parameters for query.</param>
        /// <returns>URI with API request.</returns>
        public Uri ComposeSearchAuctionQuery(IDictionary<string, string> search)
        {
            var requestAddress = SearchQuery;
			var sm = new SettingsManager();
			requestAddress += sm.KokosWebApiKey;
			foreach (var item in search)
            {
                requestAddress += "&" + item.Key + "=" + item.Value;
            }
            requestAddress += DataType;
            var result = new Uri(requestAddress);
			return result;
        }
    }
}
