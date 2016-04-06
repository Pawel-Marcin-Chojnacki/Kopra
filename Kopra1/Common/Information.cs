using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Kopra.Common
{
    /// <summary>
    /// Class representing information service.
    /// </summary>
    class Information
    {
        /// <summary>
        /// Shows flyout with information passed in argument.
        /// </summary>
        /// <param name="sender">Object on which flyout will be displayed.</param>
        /// <param name="statement">Information to display in flyout.</param>
        public static void ShowFlyoutInfo(object sender, string statement)
        {
            var flyout = new Flyout();
            var grid = new Grid();
            grid.Children.Add(new TextBlock
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
