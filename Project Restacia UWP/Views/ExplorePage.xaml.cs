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
using Windows.Storage;
using WinUIEx;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Project_Restacia_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExplorePage : Page
    {
        public ExplorePage()
        {
            this.InitializeComponent();
        }

        private void article1btn_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["wv2uri"] = "https://sites.google.com/moe-dl.edu.my/restacia/how-to-prevent/suggested-activities";
            localSettings.Values["wv2title"] = "Restacia • Meditate with these activities!";
            BrowserView bv = new BrowserView();
            bv.Activate();
            bv.Show();

        }

        private void article2btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SpotifyView));
        }

        private void article3btn_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["wv2uri"] = "https://sites.google.com/moe-dl.edu.my/restacia/how-to-prevent/suggested-menu";
            localSettings.Values["wv2title"] = "Restacia • When dietary meets psychology";
            BrowserView bv = new BrowserView();
            bv.Activate();
            bv.Show();
        }

        private void article4btn_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["wv2uri"] = "https://sites.google.com/moe-dl.edu.my/restacia/how-to-prevent";
            localSettings.Values["wv2title"] = "Restacia • An emotional care tip";
            BrowserView bv = new BrowserView();
            bv.Activate();
            bv.Show();
        }

        private void act1_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["wv2uri"] = "https://slowroads.io";
            localSettings.Values["wv2title"] = "Restacia • slowroads.io";
            BrowserView bv = new BrowserView();
            bv.Activate();
            bv.Show();
        }

        private void act2_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["wv2uri"] = "https://gradiyent.netlify.app";
            localSettings.Values["wv2title"] = "Restacia • Gradiyent";
            BrowserView bv = new BrowserView();
            bv.Activate();
            bv.Show();
        }

        private void act3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BreathMeditation));
        }

        private void act4_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["wv2uri"] = "https://www.crazygames.com/t/relaxing";
            localSettings.Values["wv2title"] = "Restacia • Crazy Games";
            BrowserView bv = new BrowserView();
            bv.Activate();
            bv.Show();
        }

        private void act5_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dg = new ContentDialog();
            dg.Title = "Stay tuned!";
            dg.Content = "This feature is currently in development. We'll be releasing new features over time, so be sure to check out later!";
            dg.CloseButtonText = "Cool!";
            dg.DefaultButton = ContentDialogButton.Close;
            dg.XamlRoot = this.XamlRoot;
            dg.ShowAsync();
        }
    }
}
