using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Kopra1.Model.Auction;

namespace Kopra.Common
{
    public class DataService
    {

		private SettingsManager credentials ;
		public async Task<ObservableCollection<Auction>> GetRecentAuctions()
        {
            var result = new ObservableCollection<Auction>();
            var rg = new RequestGenerator();
            KokosConnectionManager.GetWebApiKeyFromService();
			SearchAuctionResult mostRecentAuctions = await KokosConnectionManager.SendRestRequest(rg.MostRecentAuctions());
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
		    result = await KokosConnectionManager.GetAuctionDataRequest(requestAddress);
		    return result;
	    }
    }
}
