using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kopra;

namespace Kopra.ViewModel
{
    public class MainMenuViewModel : MainViewModel
    {
        private DataService dataService = new DataService();

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

        public MainMenuViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            RecentAuctions = new NotifyTaskCompletion<ObservableCollection<Auction>>(dataService.GetRecentAuctions());
        }

    }
}
