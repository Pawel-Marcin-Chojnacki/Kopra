using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Kopra1.Annotations;

namespace Kopra.ViewModel
{
    class ShowFiltersViewModel: MainViewModel
    {
	    public ShowFiltersViewModel()
	    {
		    StoredFiles = GetStoredFiles().Result;
			ICustomFormatter formatter = new BinaryFo 
	    }

	    private IReadOnlyList<StorageFile> StoredFiles { get; set; }
		
	    private async Task<IReadOnlyList<StorageFile>> GetStoredFiles()
	    {
			// Get the app's installation folder.
			StorageFolder appFolder =
				ApplicationData.Current.LocalFolder; 

			// Get the files in the current folder.
			IReadOnlyList<StorageFile> filesInFolder =
					  await appFolder.GetFilesAsync();

			// Iterate over the results and print the list of files
			// to the Visual Studio Output window.
			//foreach (StorageFile file in filesInFolder)
			//	Debug.WriteLine(file.Name + ", " + file.DateCreated);

		    return filesInFolder;
	    }





		internal async void ReadFilter(string filterName)
	    {

			

			//StorageFolder folder = ApplicationData.Current.LocalFolder;
		 //   if (folder != null)
		 //   {
			//    StorageFile file = await folder.GetFileAsync(filterName);
		 //   }
			  
	    }

		}
	}

