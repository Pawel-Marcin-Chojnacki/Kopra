using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Kopra.Model.Auction;

namespace Kopra
{
	/// <summary>
	/// Class responsible for generating Web API url's for REST server.
	/// </summary>
	public class RequestGenerator
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

		public Uri SearchAuction(Dictionary<string, string> search)
		{
			var requestAddress = BaseAddress + "search?";
			foreach (var item in search)
			{
				requestAddress += item.Key + "=" + item.Value + "&";
			}
			requestAddress += DataType;
			var result = new Uri(requestAddress);
			return result;
		}

		/// <summary>
		/// Composes new query for searching.
		/// </summary>
		/// <param name="search">Dictionary with parameters for query.</param>
		/// <returns>URI with API request.</returns>
		public Uri ComposeSearchAuctionQuery(Dictionary<string, string> search)
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

			Debug.WriteLine(result.ToString());
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
			requestAddress += Key + sm.KokosWebApiKey;
			requestAddress += DataType + "&";
			requestAddress += Records + "3";
			var result = new Uri(requestAddress);
			Debug.WriteLine(result.ToString());
			return result;
		}

		public Uri GetAuctionData(GetAuctionDataParameters parameters)
		{
			var settingsManager = new SettingsManager();
			var reqBuilder = new StringBuilder();
			reqBuilder.Append(BaseAddress);
			reqBuilder.Append(AuctionData);
			reqBuilder.Append(Key);
			reqBuilder.Append(settingsManager.KokosWebApiKey);
			reqBuilder.Append("&");
			reqBuilder.Append(Id);
			reqBuilder.Append(parameters.Id);
			reqBuilder.Append("&");
			reqBuilder.Append(Comments);
			reqBuilder.Append("&");
			reqBuilder.Append(Type);
			reqBuilder.Append(parameters.DataType);
			return new Uri(reqBuilder.ToString());
		}
	}
}
