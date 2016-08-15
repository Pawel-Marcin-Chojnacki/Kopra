using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kopra.Annotations;
using Kopra.Common;

namespace Kopra.ViewModel
{
    public class SearchAuctionViewModel : MainViewModel
    {
		public NotifyTaskCompletion<ObservableCollection<Auction>> Auctions { get; set; }
		private DataService dataService = new DataService();

		public void SearchAuction(Uri request )
		{
			Auctions =  new NotifyTaskCompletion<ObservableCollection<Auction>>(dataService.GetAuctionsByParameters(request));
		}

	}
}
