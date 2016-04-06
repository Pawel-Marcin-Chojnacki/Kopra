using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;

namespace Kopra.Common
{
    public class ConnectionManager
    {
        public bool CheckInternetConnection()
        {
            var isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isConnected)
            {
                var internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                var connection = internetConnectionProfile.GetNetworkConnectivityLevel();
                if (connection != NetworkConnectivityLevel.None && connection != NetworkConnectivityLevel.LocalAccess) return true;
            }
            OnInternetConnectionFail?.Invoke();
            return false;
        }

        public delegate void InternetConnectionFail();

        public event InternetConnectionFail OnInternetConnectionFail;

    }
}
