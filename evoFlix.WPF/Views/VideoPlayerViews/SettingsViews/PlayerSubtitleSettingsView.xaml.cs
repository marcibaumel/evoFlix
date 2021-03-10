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
    /// TO-DO:
    /// -Set the owner of the window (to be able reopen it)
    /// -Set the initial position of the sample text in the layout tab
    /// -Solve Subtitle Text Shadow problem (in the settings and in the binding)
    /// -Rearrange the Apperance Tab
    /// -Save the settings
    /// -Implement the "Download Subtitle" section (LATER)
    /// -Set MinWidth and MaxWidth properties (OPTIONAL)
    /// -Implement commands (OPTIONAL)
    /// -Add up and down arrows to the position tab (OPTIONAL)
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

            if (Heap.ActualSubtitle.Source != null)
            {
                AvailableSubtitles = new List<ListBoxItem>();
                foreach (var subtitle in Heap.ActualSubtitle.AvailableSubtitlePaths)
                    AddItemToAvailableSubtitles(subtitle);
                lsbSubtitles.ItemsSource = AvailableSubtitles;

                cmbFonts.SelectedItem = txtPreview.FontFamily;
                defaultFontFamily = txtPreview.FontFamily;
            }

            Canvas.SetTop(positionSampleText, SubtitleTextPropertiesProvider.Instance.Ratio * Canvas.ActualHeight);
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

        #region Position Tab Functions
        private void positionSampleText_MouseMove(object sender, MouseEventArgs e)
        {
            Border movingText = (Border)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Point p = e.GetPosition(Canvas);
                double currentLocation = p.Y - movingText.ActualHeight / 2;
                if (currentLocation < 0)
                    Canvas.SetTop(movingText, 0);
                else if (currentLocation + movingText.ActualHeight > Canvas.ActualHeight)
                    Canvas.SetTop(movingText, Canvas.ActualHeight - movingText.ActualHeight);
                else
                    Canvas.SetTop(movingText, currentLocation);
                movingText.CaptureMouse();
            }
            else
            {
                movingText.ReleaseMouseCapture();
            }
        }

        
        private void btnApplyPosition_Click(object sender, RoutedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.SetRatio(Canvas.GetTop(positionSampleTextBorder), Canvas.ActualHeight);
            SubtitleTextPropertiesProvider.Instance.SetPosition();
        }

        private void positionSampleText_MouseEnter(object sender, MouseEventArgs e)
        {
            positionSampleTextBorder.Background.Opacity = 0.3;
        }

        private void positionSampleTextBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            positionSampleTextBorder.Background.Opacity = 0;
        }

        #endregion
    }
}
