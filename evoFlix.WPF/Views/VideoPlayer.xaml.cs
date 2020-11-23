using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace evoFlix.WPF.Views
{
    /// TO-DO:
    ///     - Button images
    ///     - Update the video with slider and vica versa
    ///     - Add tootip to the slider
    ///     - Add logic to the other buttons
    ///     - Go back to another page with the back button
    ///     - Save the current time
    ///     - Load the saved time
    /// 
    public partial class VideoPlayer : Page
    {
        public VideoPlayer()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mdaVideo.Pause();
        }
    }
}
