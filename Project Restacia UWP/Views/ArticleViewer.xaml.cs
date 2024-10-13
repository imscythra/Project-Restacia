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
using System.Net;
using System.Security.Policy;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using Windows.Graphics.Printing.PrintSupport;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Project_Restacia_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticleViewer : Page
    {
        public ArticleViewer()
        {
            this.InitializeComponent();
            articleloader();
        }
        
        private async void articleloader()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    // Read the stream as a string.
                    // Fetch the content from the URL
                    string content = await client.GetStringAsync("https://raw.githubusercontent.com/imscythra/restacia-articlesdb/main/article_spotify.md");
                    // Set the TextBlock's text
                    articleMDarea.Text = content;


                }
                catch (IOException e)
                {
                    articleMDarea.Text = ("The file could not be read: ");
                    articleMDarea.Text += (e.Message);
                }
            }
        }
    }
}
