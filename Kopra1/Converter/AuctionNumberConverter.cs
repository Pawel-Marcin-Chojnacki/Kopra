using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Kopra1.Model.Auction;

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
			string objValue = (string)value;
			return $"Akucja nr {objValue}";
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
