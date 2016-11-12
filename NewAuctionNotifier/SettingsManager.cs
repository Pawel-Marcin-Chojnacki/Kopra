using System.Collections.Generic;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace Kopra.NewAuctionNotifier
{
    public sealed class SettingsManager
    {
        private readonly IPropertySet _values;
        private const string LiveTileKey = "liveTile";
        private const string KokosWebApiKeyKey = "kokosWebApiKey";
        private const string EmailKey = "email";
        private const string PasswordKey = "password";
        private const string UserNameKey = "userName";
        private const string FiltersListKey = "filters";
        private const string KokosWebApiValidKey = "kokosWebApiValid";

        public void ClearData()
        {
            _values.Clear();
        }
        public SettingsManager()
        {
            _values = ApplicationData.Current.LocalSettings.Values;
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

        public string KokosWebApiValid
        {
            get
            {
                if (_values.ContainsKey(KokosWebApiValidKey))
                    return (string)_values[KokosWebApiValidKey];
                return null;
            }

            set
            {
                _values[KokosWebApiValidKey] = value;
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

        //public List<Dictionary<string,SearchAuctionFields>> Filters
        //{
        //    get
        //    {
        //        if(_values.ContainsKey(FiltersListKey))
        //        {
        //            //List<Dictionary<string,SearchAuctionFields>> filter = (List<Dictionary<string, SearchAuctionFields>>)_values[FiltersListKey];
        //            return (List<Dictionary<string, SearchAuctionFields>>)_values[FiltersListKey];
        //        }
        //        return null;
        //    }
        //    set
        //    {
        //        _values[FiltersListKey] = value;
        //    }
        //}
    }
}
