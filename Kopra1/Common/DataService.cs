using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kopra
{
    public class DataService
    {
        public async Task<ObservableCollection<Auction>> GetRecentAuctions()
        {
            var result = new ObservableCollection<Auction>();
            var rg = new RequestGenerator();
            ConnectionManager.GetWebApiKeyFromService();
            var mostRecentAuctions = await ConnectionManager.SendRestRequest(rg.MostRecentAuctions());
            foreach (var auction in mostRecentAuctions.response.auctions.auction)
            {
                result.Add(auction);
            }
            return result;
        }
    }
}
