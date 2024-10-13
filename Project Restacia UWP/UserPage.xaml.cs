using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_Restacia_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserPage : Page
    {
        public UserPage()
        {
            this.InitializeComponent();
        }

        private async void addUser_button_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Coming soon! 🚧";
            dialog.Content = "This feature is still in development. Stay tuned!";
            dialog.CloseButtonText = "Dismiss";
            dialog.DefaultButton = ContentDialogButton.Close;
            /* TODO You should replace 'this' with the instance of UserControl that this ContentDialog is meant to be a part of. */
            await dialog.ShowAsync();
        }

         private static ContentDialog SetContentDialogRoot(ContentDialog contentDialog, UserControl control)
         {
            if (Windows.Foundation.Metadata.ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 8))
            {
                contentDialog.XamlRoot = control.Content.XamlRoot;
            }
            return contentDialog;
        }

        private async void user1_button_Click(object sender, RoutedEventArgs e)
        {
            userScreen_view.Visibility = Visibility.Collapsed;
            loadingScreen_view.Visibility = Visibility.Visible;
            Random rnd = new Random();
            await Task.Delay(rnd.Next(1500,3000));
            this.Frame.Navigate(typeof(MainPage), null, new DrillInNavigationTransitionInfo());
        }
    }
}
