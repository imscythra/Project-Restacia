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
    public sealed partial class apikeydialog : ContentDialog
    {
        public apikeydialog()
        {
            this.InitializeComponent();
        }

        private void Getkey_Click(object sender, RoutedEventArgs e)
        {

        }

        private void APIKeyBox_Toggle_Click(object sender, RoutedEventArgs e)
        {
            if (APIKeyBox_Toggle.IsChecked == true) { APIKeyBox.PasswordRevealMode = PasswordRevealMode.Visible; }
            else { APIKeyBox.PasswordRevealMode = PasswordRevealMode.Hidden; }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (APIKeyBox.Password == string.Empty) { localSettings.Values.Remove("apiKey"); }
            else { localSettings.Values["apiKey"] = APIKeyBox.Password; }
            Hide();
        }
    }
}
