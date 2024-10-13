using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Project_Restacia_UWP.Views
{
    public sealed partial class SpotifyAuthDialog : ContentDialog
    {
        public SpotifyAuthDialog()
        {
            Environment.SetEnvironmentVariable("WEBVIEW2_DEFAULT_BACKGROUND_COLOR", "0");
            this.InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void authwv_NavigationStarting(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs args)
        {
            loadindicator.Opacity = 1;
            authwv.Opacity = 0;
        }

        private void authwv_NavigationCompleted(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (authwv.Source.ToString().Contains("open.spotify.com") & !authwv.Source.ToString().Contains("login")) { localSettings.Values["spotifyAuth"] = "true"; Hide();}
            else
            {
                loadindicator.Opacity = 0;
                authwv.Opacity = 1;
                localSettings.Values["spotifyAuth"] = "false";
            }
        }
    }
}
