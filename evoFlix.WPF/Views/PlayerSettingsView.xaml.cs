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
    /// <summary>
    /// Interaction logic for PlayerSettingsView.xaml
    /// </summary>
    public partial class PlayerSettingsView : UserControl
    {
        private PlayerSubtitleSettingsView subtitlesView = new PlayerSubtitleSettingsView();
        public PlayerSettingsView()
        {
            InitializeComponent();
            
        }

        private void btnSubtitles_Click(object sender, RoutedEventArgs e)
        {
            SettingsItemFrame.Content = subtitlesView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
