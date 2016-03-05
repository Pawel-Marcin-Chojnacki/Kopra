using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Kopra1.Common
{
    class Information
    {
        public static void ShowNoConnectionInfo(object sender, string statement)
        {
            var flyout = new Flyout();
            var grid = new Grid();
            grid.Children.Add(new TextBlock()
            {
                Text = statement,
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center
            });
            flyout.Content = grid;
            flyout.ShowAt(sender as FrameworkElement);
        }
    }
}
