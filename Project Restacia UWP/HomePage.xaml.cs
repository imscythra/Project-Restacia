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
using Project_Restacia_UWP.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project_Restacia_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    using System;
    using Microsoft.UI.Xaml.Controls;
    using Windows.Storage;
    using WinUIEx;

    public class QuoteGenerator
    {
        private static readonly string[] Quotes = new[]
        {
        "Sometimes the most important thing in a whole day is the rest we take between two deep breaths",
        "You are not alone. You are seen. You are heard. You are loved.",
        "Just when the caterpillar thought the world was over, it became a butterfly.",
        "Healing takes time, and asking for help is a courageous step",
        "Your story is not over. Just because it’s hard right now doesn’t mean it will always be.",
        "The greatest glory in living lies not in never falling, but in rising every time we fall.",
        "You don’t have to be perfect to be amazing.",
        "It’s okay to not be okay, but it’s not okay to stay that way.",
        "Believe you can and you’re halfway there.",
        "Every day may not be good, but there’s something good in every day.",
        "Stars can’t shine without darkness.",
        "Sometimes you have to go through the darkest times to see the light.",
        "Even if you're as useless as me (a placeholder), what you give positive is still positive.",
        "Remember that mental health is a luxury to be grateful of.",
        "The developer said this feature is still in development, at least he has determination!",
    };

        public static void SetRandomQuote(TextBlock qotdText)
        {
            var random = new Random();
            int index = random.Next(Quotes.Length);
            qotdText.Text = Quotes[index];
        }
    }


    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            QuoteGenerator.SetRandomQuote(qotdText);
            
            // save quote in a temporary storage
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["quoteText"] = qotdText.Text;


        }

        private async void qotdButton_Click(object sender, RoutedEventArgs e)
        {
            QuoteOfTheDayDialog qotd = new QuoteOfTheDayDialog();
            qotd.CloseButtonText = "Dismiss";
            qotd.DefaultButton = ContentDialogButton.Close;
            qotd.XamlRoot = this.XamlRoot;
            await qotd.ShowAsync();
        }

        private void featured_Chat_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ChatbotView));
        }

        private void exploreMore_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ExplorePage));
        }

        private void feedbackButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dg = new ContentDialog();
            dg.Title = "Stay tuned!";
            dg.Content = "This feature is currently in development. We'll be releasing new features over time, so be sure to check out later!";
            dg.CloseButtonText = "Cool!";
            dg.DefaultButton = ContentDialogButton.Close;
            dg.XamlRoot = this.XamlRoot;
            dg.ShowAsync();
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
    }
}
