using System;
using System.Collections.ObjectModel;
using Kopra.Common;

namespace Kopra.ViewModel
{
	public class SearchAuctionViewModel : MainViewModel
	{
		public NotifyTaskCompletion<ObservableCollection<Auction>> Auctions { get; set; }
		private DataService dataService = new DataService();

		public void SearchAuction(Uri request ) => Auctions =  new NotifyTaskCompletion<ObservableCollection<Auction>>(AuctionDownloader.GetAuctionsByParameters(request));
	}
}
