using Kopra.Common;
using Kopra.Model.Auction;

namespace Kopra.ViewModel
{
	public class AuctionDataViewModel : MainViewModel
	{
		private GetAuctionDataParameters Request;

		private GetAuctionDataResponse auction;

		private DataService ds;

		public string Id { get; set; }
		private Model.Auction.Auction _auction;

		public Model.Auction.Auction Auction {
			get
			{
				return _auction;
			}
			set
			{
				SetUnitsInAuction(value);
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
			Request = new GetAuctionDataParameters {Id = Id, DataType = "json"};
			Auction = await ds.GetAuctionData(Request);
		}

		private void SetUnitsInAuction(Model.Auction.Auction auction)
		{
			if (!string.IsNullOrWhiteSpace(auction.value))
			{
				auction.value = auction.value + " zł";
			}
			if (!string.IsNullOrWhiteSpace(auction.period))
			{
				auction.period = auction.period + " mies.";
			}
			if (!string.IsNullOrWhiteSpace(auction.percent))
			{
				auction.percent = auction.percent + "%";
			}
			if (!string.IsNullOrWhiteSpace(auction.timeToEnd))
			{
				int timeLeft, day = 24*60, hour = 60;
				string unit;
				if (int.TryParse(auction.timeToEnd,out timeLeft))
				{
					if (timeLeft > day)
					{
						unit = (timeLeft / day) == 1 ? " dzień" : " dni";
						auction.timeToEnd = (timeLeft / day).ToString() + unit;
					} else if (timeLeft > hour)
					{
						unit = " godz.";
						auction.timeToEnd = (timeLeft / hour).ToString() + unit;
					}
					else
					{
						unit = " min.";
						auction.timeToEnd += unit;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(auction.PB.age))
			{
				var borrowerAge = int.Parse(auction.PB.age);
				var lastDigitOfAge = borrowerAge % 10;
				if ((lastDigitOfAge >= 0) && (lastDigitOfAge <= 4))
				{
					auction.PB.age += " lata";
				}
				else
				{
					auction.PB.age += " lat";
				}
			}
			NotifyPropertyChanged(nameof(Auction));
		}
	}
}