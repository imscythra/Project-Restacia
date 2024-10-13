using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Project_Restacia_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SpotifyView : Page
    {
        public SpotifyView()
        {
            this.InitializeComponent();
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Object authCheck = localSettings.Values["spotifyAuth"];
            if (authCheck != null)
            {
                if (authCheck.ToString() == "true") { continuefromAuth(); }
                else { playerView.Visibility = Visibility.Collapsed; spotifyAuthView.Visibility = Visibility.Visible; }
            }

            else { playerView.Visibility = Visibility.Collapsed; spotifyAuthView.Visibility = Visibility.Visible; }
            spotifywv2.CoreWebView2Initialized += delegate
            {
                IsCoreInitialized = true;
                OriginalUserAgent = spotifywv2.CoreWebView2.Settings.UserAgent;
                GoogleSignInUserAgent = OriginalUserAgent.Substring(0, OriginalUserAgent.IndexOf("Edg/"))
                .Replace("Mozilla/5.0", "Mozilla/4.0");
                spotifywv2.CoreWebView2.Settings.UserAgent = GoogleSignInUserAgent;

            };
        }
        public bool IsCoreInitialized { get; private set; }
        string OriginalUserAgent;
        string GoogleSignInUserAgent;
        private async void spotifyLoginButton_Click(object sender, RoutedEventArgs e)
        {
            spotifyLoginButton.IsEnabled = false;
            await Task.Delay(500);
            SpotifyAuthDialog dialog = new SpotifyAuthDialog();
            dialog.XamlRoot = this.XamlRoot;
            await dialog.ShowAsync();
            spotifyLoginButton.IsEnabled = true;
        }

        public void continuefromAuth()
        {
            playerView.Visibility = Visibility.Visible;
            spotifyAuthView.Visibility = Visibility.Collapsed;
        }

        private async void spotifywv2_NavigationStarting(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs args)
        {
            if (spotifywv2.Source.ToString().Contains("accounts.spotify.com/en/login"))
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                localSettings.Values["spotifyAuth"] = "false";
                playerView.Visibility = Visibility.Collapsed;
                spotifyAuthView.Visibility = Visibility.Visible;
                SpotifyAuthDialog dialog = new SpotifyAuthDialog();
                dialog.XamlRoot = this.XamlRoot;
                await dialog.ShowAsync();
                Object authCheck = localSettings.Values["spotifyAuth"];
                if (authCheck.ToString() == "true") { continuefromAuth(); }


            }
            wvNavHandler();
            loadbar.IsIndeterminate = true;
            loadbar.Visibility = Visibility.Visible;
        }

        private void wvNavHandler()
        {
            if (spotifywv2.CanGoBack == true) { backButton.IsEnabled = true; } else { backButton.IsEnabled = false; }
            if (spotifywv2.CanGoForward == true) { fwdButton.IsEnabled = true; } else { fwdButton.IsEnabled = false; }
        }

        private async void spotifywv2_NavigationCompleted(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            if (spotifywv2.Source.ToString().Contains("accounts.spotify.com/en/login"))
            {
                playerView.Visibility = Visibility.Collapsed;
                spotifyAuthView.Visibility = Visibility.Visible;
                SpotifyAuthDialog dialog = new SpotifyAuthDialog();
                dialog.XamlRoot = this.XamlRoot;
                await dialog.ShowAsync();
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                Object authCheck = localSettings.Values["spotifyAuth"];
                if (authCheck.ToString() == "true") { continuefromAuth(); }

            }
            loadbar.IsIndeterminate = false;
            loadbar.Visibility = Visibility.Collapsed;
            wvNavHandler();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (spotifywv2.CanGoBack == true) { spotifywv2.GoBack(); }
        }

        private void fwdButton_Click(object sender, RoutedEventArgs e)
        {
            if (spotifywv2.CanGoForward == true) { spotifywv2.GoForward(); }
        }
    }
}
