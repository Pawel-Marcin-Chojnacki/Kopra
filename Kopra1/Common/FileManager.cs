using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;

namespace Kopra.Common
{
	public static class FileManager
	{
		public static async Task WriteJsonAsync(object T, string fileName)
		{
			var serializer = new DataContractJsonSerializer(T.GetType());
			using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
						  fileName,
						  CreationCollisionOption.ReplaceExisting))
			{
				serializer.WriteObject(stream, T);
			}
		}

		public static async Task<T> DeserializeJsonAsync<T>(string fileName)
		{
			T resultContent = default(T);
			string content = string.Empty;
			var jsonSerializer = new DataContractJsonSerializer(typeof(T));
			var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(fileName);
			resultContent = (T)jsonSerializer.ReadObject(myStream);
			return resultContent;
		}
	}
}
