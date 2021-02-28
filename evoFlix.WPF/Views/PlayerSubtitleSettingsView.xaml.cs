using evoFlix.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public List<ListBoxItem> AvailableSubtitles { get; set; }
        private const int MaxListBoxItemLength = 30;
        public PlayerSubtitleSettingsView()
        {
            InitializeComponent();
            AvailableSubtitles = new List<ListBoxItem>();
            foreach (var subtitle in Heap.ActualSubtitle.AvailableSubtitlePaths)
                AddItemToAvailableSubtitles(subtitle);
            lsbSubtitles.ItemsSource = AvailableSubtitles;
            
        }

        private void AddItemToAvailableSubtitles(string subtitle)
        {
            ListBoxItem item = new ListBoxItem();
            item.ToolTip = subtitle;
            if (subtitle.Length <= MaxListBoxItemLength)
                item.Content = subtitle;
            else
                item.Content = Regex.Replace(subtitle, @"^(?<begin>.{30}).*(?<ext>\" + System.IO.Path.GetExtension(subtitle) + ")$", @"${begin} ... ${ext}");

            AvailableSubtitles.Add(item);
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            Heap.ActualSubtitle.SetActualSubtitle(lsbSubtitles.SelectedItem.ToString());
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
                AddItemToAvailableSubtitles(openFileDialog.FileName);
                lsbSubtitles.ItemsSource = null;
                lsbSubtitles.ItemsSource = AvailableSubtitles;
            }
        }
    }
}
