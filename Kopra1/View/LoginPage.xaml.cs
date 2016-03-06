using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;
using Kopra.Common;
using Kopra.Theme;
using Kopra.ViewModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Kopra
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private NavigationHelper _navigationHelper;
        private ObservableDictionary _defaultViewModel = new ObservableDictionary();
        private SettingsManager _settingsManager;
        private ConnectionManager _connectionManager;
        private LoginPageViewModel _viewModel;
        //private bool _loginSuccessful = false;
        private bool internetConnected = false;

        public LoginPage()
        {
            this.InitializeComponent();

            _viewModel = this.DataContext as LoginPageViewModel;
            _settingsManager = new SettingsManager();
            _connectionManager = new ConnectionManager();
            _connectionManager.OnInternetConnectionFail += ConnectionManagerOnInternetConnectionFail;
            this._navigationHelper = new NavigationHelper(this);
            this._navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this._navigationHelper.SaveState += this.NavigationHelper_SaveState;
            StatusBarManager.Hide();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            internetConnected = _connectionManager.CheckInternetConnection();
            Email.Text = "hakerpawel@gmail.com";
            Password.Password = "pawelek992CHOJ!";
        }


        /// <summary>
        /// Connects to "InternetConnectionFail" event.
        /// </summary>
        private void ConnectionManagerOnInternetConnectionFail()
        {
            Information.ShowFlyoutInfo(this, "Brak połączenia z internetem.");
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this._navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this._defaultViewModel; }
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
            Frame.BackStack.Clear();
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
            this._navigationHelper.OnNavigatedTo(e);
            if (IsCredentialStoredInLocalStorage() && internetConnected)
            {
                _viewModel.FillLoginForm(_settingsManager.Email, _settingsManager.Password);
                NavigateToMainPage();
            }

        }

        #endregion

        private bool IsCredentialStoredInLocalStorage()
        {
            if (_settingsManager.Email != null && _settingsManager.Password != null) return true;
            return false;
        }

        private async void NavigateToMainPage()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                () => this.Frame.Navigate(typeof(MainMenuPage)));
        }


        //private bool IsLoginDataCorrect()
        //{
        //    return true;
        //    throw new NotImplementedException();
        //}

        

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this._navigationHelper.OnNavigatedFrom(e);
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (_connectionManager.CheckInternetConnection() == false)
                return;
            if (!IsEmailValid(Email.Text))
            {
                Information.ShowFlyoutInfo(this, "Sprawdź czy email jest poprawny.");
                EmailStoryboard.Begin();
                return;
            }
            if (!IsPassordValid(Password.Password))
            {
                Information.ShowFlyoutInfo(this, "Sprawdź wpisane hasło.");
                PasswordStoryboard.Begin();
                return;
            }

            DisableLoginForm();
            await LoginToServiceAsync(Email.Text, Password.Password);
            Frame.Navigate(typeof(MainMenuPage));
            
        }

        private bool IsPassordValid(string password)
        {
            if (password.Length < 6)
            {
                return false;
            }
            return true;
        }

        private bool IsEmailValid(string email)
        {
            if (!email.Contains("@") || !email.Contains(".") || email.Length < 6)
            {
                return false;
            }
            return true;
        }

        private void DisableLoginForm()
        {
            Email.IsEnabled = false;
            Password.IsEnabled = false;
            LoginButton.Visibility = Visibility.Collapsed;
            ProgressIndicator.Visibility = Visibility.Visible;
        }

        private static IAsyncAction LoginToServiceAsync(string t, string p)
        {
            //await KokosConnectionManager.LoginToService(t, p);
            return Task.Run(async() =>
            {
                await KokosConnectionManager.LoginToService(t, p);
            }).AsAsyncAction();
        }

        /// <summary>
        /// Change focus to password when enter key is pressed in email field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Email_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                Password.Focus(FocusState.Keyboard);
            }
        }

        /// <summary>
        /// Login action when enter key is pressed in password field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                LoginButton.Focus(FocusState.Keyboard);
                loginButton_Click(sender, e);
            }
                
        }
    }
}
