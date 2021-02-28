using evoFlix.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for PlayerSubtitleSettingsView.xaml
    /// </summary>
    public partial class PlayerSubtitleSettingsView : UserControl
    {
        public List<string> AvailableSubtitles { get; set; }
        public PlayerSubtitleSettingsView()
        {
            InitializeComponent();
            AvailableSubtitles = Heap.ActualSubtitle.AvailableSubtitlePaths;
            lsbSubtitles.ItemsSource = AvailableSubtitles;
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            Heap.ActualSubtitle.SetActualSubtitle(lsbSubtitles.SelectedItem.ToString());
            MessageBox.Show(lsbSubtitles.SelectedItem.ToString());
        }

        private void btnSelectLocal_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() 
            { 
                Filter = ".srt files (*.srt)|*.srt|.ass files (*.ass)|*.ass", 
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
            };
            if (openFileDialog.ShowDialog() == true)
            {
                AvailableSubtitles.Add(openFileDialog.FileName);
                lsbSubtitles.ItemsSource = null;
                lsbSubtitles.ItemsSource = AvailableSubtitles;
            }
        }
    }
}
