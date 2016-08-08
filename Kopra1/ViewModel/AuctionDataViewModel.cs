using Kopra.Common;
using Kopra1.Model.Auction;

namespace Kopra.ViewModel
{
    public class AuctionDataViewModel : MainViewModel
    {
	    private GetAuctionDataParameters Request;

	    private GetAuctionDataResponse auction;

	    private DataService ds;

	    public string Id { get; set; }
	    private Model.Auction.Auction _auction;
			
		public Model.Auction.Auction Auction { get {return _auction;}
			set
			{
				_auction = value;
				NotifyPropertyChanged(nameof(Auction));
			}
		}
	    public AuctionDataViewModel()
	    {
			ds = new DataService();
		}

	    public async void GetAuctionData()
	    {
		    Request = new GetAuctionDataParameters() {Id = Id, DataType = "json"};
		    Auction = await ds.GetAuctionData(Request);
	    }
    }
}