using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Kopra.Common
{
    public class ConnectionManager
    {
        public bool CheckInternetConnection()
        {
            var isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isConnected)
            {
                ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                NetworkConnectivityLevel connection = internetConnectionProfile.GetNetworkConnectivityLevel();
                if (connection != NetworkConnectivityLevel.None && connection != NetworkConnectivityLevel.LocalAccess) return true;
            }
            OnInternetConnectionFail?.Invoke();
            return false;
        }

        public delegate void InternetConnectionFail();

        public event InternetConnectionFail OnInternetConnectionFail;

    }
}
