using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Kopra1.Model.Auction;
using System.Collections.Generic;

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
			SearchAuctionResult mostRecentAuctions = await KokosConnectionManager.SendRestRequest(rg.MostRecentAuctions());
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
			Uri requestAddress = request.GetAuctionData(parameters);
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
			SearchAuctionResult foundedAuctions = await KokosConnectionManager.SendRestRequest(urlAddress);
			if (foundedAuctions != null)
				foreach (var auction in foundedAuctions.response.auctions.auction)
				{
                    if (auction.status == "110" || auction.status == "100")
                        continue;
                    List<string> statusesToCheck = new List<string> { "1500", "1400", "1300" };
                    foreach (var stats in statusesToCheck)
                    {
                        if (auction.status == stats)
                            Debugger.Break();
                                            }
                    result.Add(auction);
				}
		    return result;
	    }
    }
}
