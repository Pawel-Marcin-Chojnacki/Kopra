using System;
using System.IO;
using System.Text;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Kopra.Common;
using Kopra.Model;
using Kopra.NewAuctionNotifier;
using Kopra.ViewModel;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Kopra
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private SettingsViewModel vm;
        public SettingsPage()
        {
            InitializeComponent();
            vm = DataContext as SettingsViewModel;
            navigationHelper = new NavigationHelper(this);
            navigationHelper.LoadState += NavigationHelper_LoadState;
            navigationHelper.SaveState += NavigationHelper_SaveState;
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return defaultViewModel; }
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
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            UserCredentials.SetUserName(userNameTitle);
            vm.StoredFiles = await vm.GetStoredFiles();
            vm.Filters = await vm.ReadFilters();
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
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void GenerateApiKeyButtonClick(object sender, RoutedEventArgs e)
        {
            vm.GenerateApiKey();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            var sm = new SettingsManager();
            sm.ClearData();
            KokosConnectionManager.HttpClient = new HttpClient();
            KokosConnectionManager.HttpClient.GetAsync(new Uri("https://kokos.pl/uzytkownik/autoryzacja?logout=1"));
            Frame.Navigate(typeof(LoginPage));
        }

        private async void RegisterBackgroundTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();
            if (access == BackgroundAccessStatus.Denied)
            {
                Information.ShowFlyoutInfo(this, "System odmówił rejestracji zadania. Sprawdzanie filtru nie zadziała.");
            }

            var taskBuilder = new BackgroundTaskBuilder
            {
                Name = "NewAuctionNotifier",
                TaskEntryPoint = typeof(NewAuctionsTask).FullName
            };

            var trigger = new TimeTrigger(15, false);
            taskBuilder.SetTrigger(trigger);
            taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
            taskBuilder.Register();
            SaveBackgroundTaskFile(vm.Filter.Name);
        }

        internal async void SaveBackgroundTaskFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
            {
                var msgDial = new MessageDialog("Nie wybrano filtra .");
                await msgDial.ShowAsync();
                return;
            }
            try
            {
                StorageFolder folder = ApplicationData.Current.LocalFolder;
                if (folder != null)
                {
                    var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(filename);
                    byte[] fileContent;
                    using (var reader = new StreamReader(readingStream))
                    {
                        fileContent = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                    }
                    var file = await folder.CreateFileAsync("BackgroundFilter", CreationCollisionOption.ReplaceExisting);
                    var fileStream = await file.OpenStreamForWriteAsync();
                    fileStream.Write(fileContent, 0, fileContent.Length);
                    fileStream.Flush();
                    fileStream.Dispose();
                }
            }
            catch (Exception)
            {
                var msgDial = new MessageDialog("Nie można uruchomić zadań w tle.");
                await msgDial.ShowAsync();
                //throw;
            }
        }
    }
}