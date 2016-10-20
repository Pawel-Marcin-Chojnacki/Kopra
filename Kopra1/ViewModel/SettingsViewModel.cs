using System;
using Windows.UI.Popups;
using Kopra.Model;

namespace Kopra.ViewModel
{
    public class SettingsViewModel : MainViewModel
	{
	    private string _apiKeyValue;
	    private string _apiKeyValidDate;

        SettingsManager sm = new SettingsManager();
        private ApiKeyGenerate _apiResponse;

        //private ApiKeyGenerate _apiResponse;

        public SettingsViewModel()
	    {
	        ApiKeyValue = sm.KokosWebApiKey;
	        ApiKeyValidDate = sm.KokosWebApiValid;
	    }
	    public async void GenerateApiKey()
	    {
            ApiResponse = await KokosConnectionManager.GenerateApiKeyFromService();
            CreateNewKey(ApiResponse);
            //ApiKeyValidDate = ApiResponse.ValidTime;
	    }

	    public string ApiKeyValue
	    {
	        get { return _apiKeyValue; }
	        set
	        {
	            _apiKeyValue = value;
	            NotifyPropertyChanged(nameof(ApiKeyValue));
	        }
	    }

	    public string ApiKeyValidDate
	    {
	        get { return _apiKeyValidDate; }
	        set
	        {
	            _apiKeyValidDate = value; 
	            NotifyPropertyChanged(nameof(ApiKeyValidDate));
	        }
	    }

        private async void CreateNewKey(ApiKeyGenerate value)
        {
            if (value.ValidTime != null)
            {
                ApiKeyValidDate = value.ValidTime;
            }
            MessageDialog msgBox = new MessageDialog(value.Message);
            await msgBox.ShowAsync();
        }

        public ApiKeyGenerate ApiResponse
        {
            get
            {
                return _apiResponse;
            }
            set 
            {
                _apiResponse = value;
                NotifyPropertyChanged(nameof(ApiResponse));
            }
        }
	}
}

