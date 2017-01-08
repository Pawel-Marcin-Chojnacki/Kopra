using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Kopra.Model;

namespace Kopra.ViewModel
{
	internal class ShowFiltersViewModel : MainViewModel
	{
		private ObservableCollection<SearchFilter> _filters;

		public ShowFiltersViewModel()
		{
			//StoredFiles = GetStoredFiles();
			//Filters = ReadFilters().Result;
		}

		public IReadOnlyList<StorageFile> StoredFiles { get; set; }
		public ObservableCollection<SearchFilter> Filters
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

		public async Task<IReadOnlyList<StorageFile>> GetStoredFiles()
		{
			// Get the app's installation folder.
			var appFolder =
				ApplicationData.Current.LocalFolder;

			// Get the files in the current folder.
			var filesInFolder = await appFolder.GetFilesAsync();

			return filesInFolder;
		}

		public async Task<ObservableCollection<SearchFilter>> ReadFilters()
		{
			var content = new ObservableCollection<SearchFilter>();
			foreach (var file in StoredFiles)
			{
				if (file.Name == "BackgroundFilter")
					continue;
				var readingStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(file.Name);
				using (var reader = new StreamReader(readingStream))
				{
					content.Add(new SearchFilter { Name = file.Name, Parameteres = reader.ReadToEnd() } );
				}
			}
			return content;
		}

		public void DeleteFilter(SearchFilter dataContext)
		{
			// Get the app's installation folder.
			var appFolder =
				ApplicationData.Current.LocalFolder;
			try
			{
				if (appFolder != null)
				{
					if (FileExists(dataContext.Name))
					{
						StorageFile fileToDelete = appFolder.GetFileAsync(dataContext.Name).GetAwaiter().GetResult();
						fileToDelete.DeleteAsync().GetAwaiter();
					}
					this.Filters.Remove(dataContext);
					return;
				}
				ShowDeleteErrorFlyout().GetAwaiter();
				return;
			}
			catch (Exception e)
			{
				ShowDeleteErrorFlyout().GetAwaiter();
			}
		}

		private static async Task ShowDeleteErrorFlyout()
		{
			var msgDial = new MessageDialog("Wystąpił problem podczas usuwania filtru");
			await msgDial.ShowAsync();
		}

		private bool FileExists(string fileName)
		{
			try
			{
				StorageFolder folder = ApplicationData.Current.LocalFolder;
				if (folder != null)
				{
					ApplicationData.Current.LocalFolder.GetFileAsync(fileName).GetAwaiter();
					return true;
				}
			}
			catch (Exception exception)
			{
				return false;
			}
			return false;
		}
	}
}

