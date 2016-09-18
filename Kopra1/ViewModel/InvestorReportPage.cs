using System.Collections.ObjectModel;
using Kopra.Common;
using Kopra.Model;

namespace Kopra.ViewModel
{
    public class InvestorReportPage : MainViewModel
    {
        #region fields

        private NotifyTaskCompletion<ObservableCollection<Auction>> _recentAuctions;

        #endregion

        #region properties

        public NotifyTaskCompletion<ObservableCollection<Auction>> RecentAuctions
        {
            get
            {
                return _recentAuctions;
            }
            set
            {
                _recentAuctions = value;
                NotifyPropertyChanged("RecentAuctions");
            }
        }

        #endregion

        public InvestorReportPage()
        {
            LoadData();
        }

        private void LoadData()
        {
            RecentAuctions = new NotifyTaskCompletion<ObservableCollection<Auction>>(dataService.GetRecentAuctions());
        }

    }
}