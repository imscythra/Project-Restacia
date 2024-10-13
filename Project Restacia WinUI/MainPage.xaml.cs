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
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            hostFrame.Navigate(typeof(HomePage));
            
            // NavigationView logic
            sidebar_navview.ItemInvoked += async (_, e) =>
            {
                if (!e.IsSettingsInvoked)
                    switch ((e.InvokedItemContainer as Microsoft.UI.Xaml.Controls.NavigationViewItem).Tag.ToString())
                    {
                        case "home":
                            hostFrame.Navigate(typeof(HomePage), null);
                            break;
                        case "user":
                            hostFrame.Navigate(typeof(MainPage), null);
                            break;
                        case "advanced":
                            hostFrame.Navigate(typeof(MainPage), null);
                            break;
                        case "about":
                            
                            break;
                        default: //Means else 
                            hostFrame.Navigate(typeof(MainPage), null);
                            break;
                    }
            };
        }

        private void Sidebar_navview_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void sidebar_navview_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
