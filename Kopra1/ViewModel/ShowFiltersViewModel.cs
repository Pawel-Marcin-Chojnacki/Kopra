using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Popups;
using Kopra.Common;
using Kopra.Model;
using Kopra.Annotations;

namespace Kopra.ViewModel
{
    internal class ShowFiltersViewModel : MainViewModel
	{
		private List<SearchFilter> _filters;

		public ShowFiltersViewModel()
		{
			//StoredFiles = GetStoredFiles();
			//Filters = ReadFilters().Result;
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
					content.Add(new SearchFilter() { Name = file.Name, Parameteres = reader.ReadToEnd() } );
				}
			}
			return content;
		}

	}
}

