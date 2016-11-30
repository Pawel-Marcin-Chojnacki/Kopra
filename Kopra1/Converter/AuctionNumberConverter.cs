using System;
using Windows.UI.Xaml.Data;

namespace Kopra.Converter
{
	public class AuctionNumberConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return GetAuction(value);
		}

		private object GetAuction(object value)
		{
			if (!(value is string))
				return value;
			var objValue = (string)value;
			return $"Aukcja nr {objValue}";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
