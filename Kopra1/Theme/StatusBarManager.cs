    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Kopra.Theme
{
    public static class StatusBarManager
    {
        private static StatusBar statusBar = StatusBar.GetForCurrentView();

        public static async void SetStyle()
        {
           statusBar.ShowAsync();
            statusBar.BackgroundColor = (Application.Current.Resources["AppPaletteMainAccentBrush"] as SolidColorBrush).Color;
            statusBar.BackgroundOpacity = 1;
            statusBar.ProgressIndicator.Text = " ";
            await statusBar.ProgressIndicator.ShowAsync();
            statusBar.ProgressIndicator.ProgressValue = 0;
        }

        public static async void Hide()
        {
            await statusBar.HideAsync();
        }

        public static void SetText(string text)
        {
            statusBar.ProgressIndicator.Text = text;
        }
    }
}
