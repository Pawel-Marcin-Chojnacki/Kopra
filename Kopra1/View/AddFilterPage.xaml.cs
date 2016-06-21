﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Kopra.Common;
using Kopra.ViewModel;
using System.Text;
using Windows.UI.Popups;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Kopra
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddFilterPage : Page
    {
        private NavigationHelper _navigationHelper;
        private ObservableDictionary _defaultViewModel = new ObservableDictionary();
        private AddFilterViewModel _viewModel;

        public AddFilterPage()
        {
            InitializeComponent();
            _viewModel = DataContext as AddFilterViewModel;
            _navigationHelper = new NavigationHelper(this);
            _navigationHelper.LoadState += NavigationHelper_LoadState;
            _navigationHelper.SaveState += NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return _defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void DodajAppBarButton_OnClick(object sender, RoutedEventArgs e)
        {
			if (FilterName.Text == string.Empty)
			{
				MessageDialog msgBox = new MessageDialog("Musisz wpisać nazwę filtru!");
				await msgBox.ShowAsync();
				return;
			}
			_viewModel.AddFilter();
			//_viewModel.DodajFiltr(f);

			//StringBuilder filtr = new StringBuilder();
			//foreach (var child in ContentRoot.Children)
			//{
			//	if (child.GetType() == typeof(ComboBox))
			//	{
			//		var combo = child as ComboBox;
			//		if (combo?.SelectedValue != null)
			//		{
			//			filtr.Append(combo.Name + "=");
			//			filtr.Append(combo.SelectedValue);
			//			filtr.Append("&");
			//		}
			//	}
			//	else if(child.GetType() == typeof(TextBox))
			//	{
			//		(TextBox)child.GetValue
			//	}
			//	if (child.GetType() != typeof(CheckBox)) continue;
			//	var check = child as CheckBox;
			//	if (check == null) continue;
			//	if (check.IsChecked == true)
			//	{
			//		filtr.Append(check.Name + "=");
			//		filtr.Append("1");
			//		filtr.Append("&");
			//	}
				//else //Można tego nie stosować ponieważ jeśli nie podam parametru false, jest on z góry przewidywany jako nieprawdziwy
				//{
				//    filtr.Append(check.Name + "=");
				//    filtr.Append("0");
				//    filtr.Append("&");
				//}
			//}
			//string f = filtr.ToString();
		}

        private void WyczyśćAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.WyczyśćFiltr();
        }
    }
}
