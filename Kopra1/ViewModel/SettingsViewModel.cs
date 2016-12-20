using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
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
			var msgBox = new MessageDialog(value.Message);
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

		public SearchFilter Filter
		{
			get { return _filter; }
			set { _filter = value; }
		}

		public IReadOnlyList<StorageFile> StoredFiles { get; set; }
		public List<SearchFilter> Filters
		{
			get
			{
				return _filters;
			}
			set
			{
				_filters = value;
				NotifyPropertyChanged(nameof(Filters));
			}
		}

		private List<SearchFilter> _filters;
		private SearchFilter _filter;

		public async Task<IReadOnlyList<StorageFile>> GetStoredFiles()
		{
			// Get the app's installation folder.
			var appFolder =
				ApplicationData.Current.LocalFolder;

			// Get the files in the current folder.
			var filesInFolder = await appFolder.GetFilesAsync();

			return filesInFolder;
		}

		public async Task<List<SearchFilter>> ReadFilters()
		{
			var content = new List<SearchFilter>();
			foreach (var file in StoredFiles)
			{
			    if (file.Name == "BackgroundFilter")
			        continue;
				var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(file.Name);
				using (var reader = new StreamReader(readingStream))
				{
					content.Add(new SearchFilter() { Name = file.Name, Parameteres = reader.ReadToEnd() });
				}
			}
			return content;
		}
	}
}

