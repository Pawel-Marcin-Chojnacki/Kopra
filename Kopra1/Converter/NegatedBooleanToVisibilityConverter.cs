using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Kopra.Converter
{
    class NegatedBooleanToVisibilityConverter : IValueConverter
    {
        private object GetVisibility(object value)
        {
            if (!(value is bool))
                return Visibility.Visible;
            var objValue = (bool)value;
            if (objValue)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return GetVisibility(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }


    }
}
