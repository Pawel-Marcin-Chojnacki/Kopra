using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace Kopra
{
    public  class SettingsManager
    {
        private IPropertySet _values;
        private const string LiveTileKey = "liveTile";
        private const string KokosWebApiKeyKey = "kokosWebApiKey";
        private const string EmailKey = "email";
        private const string PasswordKey = "password";
        private const string UserNameKey = "userName";
        private const string FiltersListKey = "filters";
        
        public void ClearData()
        {
            _values.Clear();
        }
        public SettingsManager()
        {
            _values = Windows.Storage.ApplicationData.Current.LocalSettings.Values;
        }

        public bool LiveTile
        {
            get
            {
                if (_values.ContainsKey(LiveTileKey))
                    return (bool)_values[LiveTileKey];
                return true;
            }

            set
            {
                _values[LiveTileKey] = value;
            }
        }

        public string KokosWebApiKey
        {
            get
            {
                if (_values.ContainsKey(KokosWebApiKeyKey))
                    return (string)_values[KokosWebApiKeyKey];
                return null;
            }

            set
            {
                _values[KokosWebApiKeyKey] = value;
            }
        }

        public string Email
        {
            get
            {
                if (_values.ContainsKey(EmailKey))
                    return (string)_values[EmailKey];
                return null;
            }

            set
            {
                _values[EmailKey] = value;
            }
        } 

        public string Password
        {
            get
            {
                if (_values.ContainsKey(PasswordKey))
                    return (string)_values[PasswordKey];
                return null;
            }

            set
            {
                _values[PasswordKey] = value;
            }
        }

        public string Username
        {
            get
            {
                if (_values.ContainsKey(UserNameKey))
                    return (string)_values[UserNameKey];
                return null;
            }
            set
            {
                _values[UserNameKey] = value;
            }
        }

        public List<Dictionary<string,SearchAuctionFields>> Filters
        {
            get
            {
                if(_values.ContainsKey(FiltersListKey))
                {
                    //List<Dictionary<string,SearchAuctionFields>> filter = (List<Dictionary<string, SearchAuctionFields>>)_values[FiltersListKey];
                    return (List<Dictionary<string, SearchAuctionFields>>)_values[FiltersListKey];
                }
                return null;
            }
            set
            {
                _values[FiltersListKey] = value;
            }
        }
    }
}
