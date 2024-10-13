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
using Microsoft.UI.Windowing;
using Microsoft.UI;
using WinUIEx;
using Windows.ApplicationModel;
using Windows.UI.WindowManagement;
using WinRT.Interop;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Project_Restacia_UWP.Views
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class DoubleToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is double actualWidth)
            {
                // Convert the double value (ActualWidth) to GridLength (Pixel)
                return new GridLength(actualWidth, GridUnitType.Pixel);
            }
            return GridLength.Auto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }


    public sealed partial class BrowserView : Window
    {
        private Microsoft.UI.Windowing.AppWindow m_AppWindow;

        public BrowserView()
        {
            this.InitializeComponent();

            Title = "Restacia • WebView2";
            ExtendsContentIntoTitleBar = true;
            m_AppWindow = GetAppWindowForCurrentWindow();
            this.m_AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
            var manager = WinUIEx.WindowManager.Get(this);
            this.CenterOnScreen();
            manager.MinWidth = 682;
            manager.MinHeight = 550;
            this.SetIsMaximizable(true);
            this.SetIsMinimizable(true);

            wv2DataLoader();

        }

        private async void wv2DataLoader()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values["wv2uri"] != null && localSettings.Values["wv2title"] != null) 
            {
                String wv2uri = localSettings.Values["wv2uri"] as string;
                String wv2title = localSettings.Values["wv2title"] as string;
                titleBarText.Text = wv2title;
                await wv2.EnsureCoreWebView2Async();
                wv2.Source = new Uri(wv2uri);
            } 
            else
            {
                //ContentDialog error = new ContentDialog();
                //error.Title = "Oops!";
                //error.Content = "Something went wrong. Please report this error to the developer:\n\nError: localSettings.wv2data is null";
                //error.PrimaryButtonText = "Dismiss";
                //error.XamlRoot = rootGrid.XamlRoot;
                //await error.ShowAsync();
                //this.Close();
            }   
        }

        private Microsoft.UI.Windowing.AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return Microsoft.UI.Windowing.AppWindow.GetFromWindowId(wndId);
        }

        private void wv2_NavigationStarting(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs args)
        {
            refreshButton.IsEnabled = false;
            navHandler();
        }

        private void navHandler()
        {
            if (wv2.CanGoBack) { wv2.GoBack(); } else { backButton.IsEnabled = false; }
        }
        private void wv2_NavigationCompleted(WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            refreshButton.IsEnabled = true;
            navHandler();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (wv2.CanGoBack) { wv2.GoBack(); } else { backButton.IsEnabled = false; }
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            wv2.Reload();
        }
    }
}
