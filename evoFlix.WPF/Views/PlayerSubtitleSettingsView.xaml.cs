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
        #region Properties
        public List<ListBoxItem> AvailableSubtitles { get; set; }
        private const int MaxListBoxItemLength = 30;
        private FontFamily defaultFontFamily;

        #endregion

        #region Constructor
        public PlayerSubtitleSettingsView()
        {
            InitializeComponent();
            
            AvailableSubtitles = new List<ListBoxItem>();
            foreach (var subtitle in Heap.ActualSubtitle.AvailableSubtitlePaths)
                AddItemToAvailableSubtitles(subtitle);
            lsbSubtitles.ItemsSource = AvailableSubtitles;

            cmbFonts.SelectedItem = txtPreview.FontFamily;
            defaultFontFamily = txtPreview.FontFamily;

            textColorPicker.SelectedColor = (Color)(SubtitleTextPropertiesProvider.Instance.Foreground).GetValue(SolidColorBrush.ColorProperty);
            SetDefaultAppearance();
        }

        #endregion

        #region General Tab Functions

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
            Heap.ActualSubtitle.SetActualSubtitle((lsbSubtitles.SelectedItem as ListBoxItem).ToolTip.ToString());
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

        #endregion

        #region Apperance Tab Functions

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.SetDefault();
            SetDefaultAppearance();
        }
        private void SetDefaultAppearance()
        {
            txtPreview.Foreground = SubtitleTextPropertiesProvider.Instance.Foreground;
            txtPreview.FontSize = SubtitleTextPropertiesProvider.Instance.FontSize;
            //cmbFonts.SelectedItem = defaultFontFamily;
            cmbFonts.SelectedItem = SubtitleTextPropertiesProvider.Instance.TextFontFamily;
            ShadowCheckBox.IsChecked = SubtitleTextPropertiesProvider.Instance.TextShadow == null ? false : true;
        }
        private void ShadowCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.SetTextShadow();
            txtPreview.Effect = SubtitleTextPropertiesProvider.Instance.TextShadow;
        }
        private void ShadowCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.ClearTextShadow();
            txtPreview.Effect = SubtitleTextPropertiesProvider.Instance.TextShadow;
        }
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.FontSize = (int)inputSize.Value;
            SubtitleTextPropertiesProvider.Instance.TextFontFamily = (FontFamily)cmbFonts.SelectedItem;
            //MessageBox.Show(((FontFamily)cmbFonts.SelectedItem).ToString());
            
            SubtitleTextPropertiesProvider.Instance.Foreground = new SolidColorBrush((Color)textColorPicker.SelectedColor);
            MessageBox.Show(SubtitleTextPropertiesProvider.Instance.Foreground.ToString());
        }
        #endregion
    }
}
