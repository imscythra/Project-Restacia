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
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Project_Restacia_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BreathMeditation : Page
    {
        public BreathMeditation()
        {
            this.InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            breathIndicator.Opacity = 0;
            progressBar.Value = 0;
            breathHandler();
        }

        private async void breathHandler()
        {
            await Task.Delay(500);
            while (progressBar.Value < 100)
            {
                breathIndicator.Value = "Inhale";
                breathIndicator.Opacity = 1;
                await Task.Delay(4000);
                breathIndicator.Opacity = 0;
                await Task.Delay(500); ;
                breathIndicator.Value = "Hold";
                breathIndicator.Opacity = 1;
                await Task.Delay(2000);
                breathIndicator.Opacity = 0;
                await Task.Delay(500); ;
                breathIndicator.Value = "Exhale";
                breathIndicator.Opacity = 1;
                await Task.Delay(4000);
                breathIndicator.Opacity = 0;
                await Task.Delay(500);
                progressBar.Value += 20;
                if (progressBar.Value != 100)
                {
                    breathIndicator.Value = "Hold";
                    breathIndicator.Opacity = 1;
                    await Task.Delay(2000);
                    breathIndicator.Opacity = 0;
                    await Task.Delay(500);
                }
            }
            menuTitle.Text = "Want to give it another shot?";
            breathIndicator.Value = "Idle";
            breathIndicator.Opacity = 1;            
        }
    }
}
