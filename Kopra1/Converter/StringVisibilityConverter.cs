﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Kopra.Converter
{
	public class StringVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var str = value as string;
			return string.IsNullOrWhiteSpace(str) ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
