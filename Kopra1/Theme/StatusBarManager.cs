    using System;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media;

namespace Kopra.Theme
{
    public static class StatusBarManager
    {
        private static StatusBar _statusBar = StatusBar.GetForCurrentView();

        public static async void SetStyle()
        {
            _statusBar.ShowAsync();
            _statusBar.BackgroundColor = (Application.Current.Resources["AppPaletteMainAccentBrush"] as SolidColorBrush).Color;
            _statusBar.BackgroundOpacity = 1;
            _statusBar.ProgressIndicator.Text = " ";
            await _statusBar.ProgressIndicator.ShowAsync();
            _statusBar.ProgressIndicator.ProgressValue = 0;
        }

        public static async void Hide()
        {
            await _statusBar.HideAsync();
        }

        public static void SetText(string text)
        {
            _statusBar.ProgressIndicator.Text = text;
        }
    }
}
