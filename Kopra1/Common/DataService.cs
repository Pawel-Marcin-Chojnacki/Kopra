using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Kopra.Model.Auction;
using System.Collections.Generic;
using System.Linq;

namespace Kopra.Common
{
	public class DataService
	{

		private SettingsManager credentials;

		public async Task<ObservableCollection<Auction>> GetRecentAuctions()
		{
			var result = new ObservableCollection<Auction>();
			var rg = new RequestGenerator();
			KokosConnectionManager.GetWebApiKeyFromService();
			var mostRecentAuctions = await KokosConnectionManager.SendRestRequest(rg.MostRecentAuctions());
			Debug.WriteLine(rg.MostRecentAuctions());
			if (mostRecentAuctions != null)
				foreach (var auction in mostRecentAuctions.response.auctions.auction)
				{
					result.Add(auction);
				}
			return result;
		}

		public async Task<Model.Auction.Auction> GetAuctionData(GetAuctionDataParameters parameters)
		{
			var result = new Kopra.Model.Auction.Auction();
			var request = new RequestGenerator();
			credentials = new SettingsManager();
			KokosConnectionManager.GetWebApiKeyFromService();
			var requestAddress = request.GetAuctionData(parameters);
			try
			{
				result = await KokosConnectionManager.GetAuctionDataRequest(requestAddress);
			}
			catch (Exception)
			{
				result = new Model.Auction.Auction();
			}
		    return result;
	    }

	    public async Task<ObservableCollection<Auction>> GetAuctionsByParameters(Uri urlAddress)
	    {
		    var result = new ObservableCollection<Auction>();
			var request = new RequestGenerator();
			var foundedAuctions = await KokosConnectionManager.SendRestRequest(urlAddress);
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
    }
}
