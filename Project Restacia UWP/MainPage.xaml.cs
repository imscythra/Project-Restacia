using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Project_Restacia_UWP.Views;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Project_Restacia_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            hostFrame.Navigate(typeof(HomePage));
            sidebar_navview.SelectedItem = 0;
            // NavigationView logic
            sidebar_navview.ItemInvoked +=  (_, e) =>
            {
                if (!e.IsSettingsInvoked)
                    switch ((e.InvokedItemContainer as Microsoft.UI.Xaml.Controls.NavigationViewItem).Tag.ToString())
                    {
                        case "home":
                            hostFrame.Navigate(typeof(HomePage), null);
                            break;
                        case "explore":
                            hostFrame.Navigate(typeof(ExplorePage), null);
                            break;
                        case "chatbot":
                            
                            // TODO: Replace the typeof target with which page to debug
                            hostFrame.Navigate(typeof(ChatbotView), null);
                            
                            break;
                        case "about":
                          
                            break;
                        default: //Means else 
                            ContentDialog dg = new ContentDialog();
                            dg.Title = "Stay tuned!";
                            dg.Content = "This feature is currently in development. We'll be releasing new features over time, so be sure to check out later!";
                            dg.CloseButtonText = "Cool!";
                            dg.DefaultButton = ContentDialogButton.Close;
                            dg.XamlRoot = this.XamlRoot;
                            dg.ShowAsync();
                            break;
                    }
            };
        }

        private void qotddebug()
        {
            
        }

        private void Sidebar_navview_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void sidebar_navview_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
           if (hostFrame.CanGoBack) { hostFrame.GoBack(); }
           else { backbtn.IsEnabled = false; }
        }

        private void hostFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (hostFrame.CanGoBack == true) { backbtn.IsEnabled = true; }
            else { backbtn.IsEnabled = false; }
        }
    }
}
