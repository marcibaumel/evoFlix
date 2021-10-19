using evoFlix.Models.Content;
using evoFlix.WPF.Models;
using evoFlix.WPF.Models.Subtitle;
using evoFlix.WPF.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;



namespace evoFlix.WPF
{
    public partial class SubtitleSettingsView : UserControl
    {
        #region Properties

        private readonly Frame frame;
        private readonly SubtitleSettingsViewModel subtitleSettingsViewModel = new SubtitleSettingsViewModel();
        private FilmTableModel film;

        #endregion

        #region Constructor

        public SubtitleSettingsView(Frame frame, FilmTableModel film)
        {
            InitializeComponent();

            this.film = film;
            this.frame = frame;
            DataContext = subtitleSettingsViewModel;

            cmbFonts.SelectedItem = txtPreview.FontFamily;

            SubtitleTextPropertiesProvider.Instance.DefaultFontFamily = txtPreview.FontFamily;

            txtMovieName.Text = film.Title;

            Canvas.SetTop(positionSampleText, SubtitleTextPropertiesProvider.Instance.Ratio * Canvas.ActualHeight);
            textColorPicker.SelectedColor = (Color)(SubtitleTextPropertiesProvider.Instance.Foreground).GetValue(SolidColorBrush.ColorProperty);
            SetDefaultAppearance();
        }

        #endregion

        #region General Tab Functions

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            if (lsbSubtitles.SelectedItem != null)
            {
                Heap.SubManager.SetCurrentSubtitle((lsbSubtitles.SelectedItem as ListBoxItem).ToolTip.ToString());
                
            }
                
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
                subtitleSettingsViewModel.AddItemToAvailableSubtitles(openFileDialog.FileName);
            }
        }

        #endregion

        #region Apperance Tab Functions

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            SetDefaultAppearance();
        }
        private void SetDefaultAppearance()
        {
            txtPreview.Foreground = SubtitleTextPropertiesProvider.Instance.DefaultForeground;
            txtPreview.FontSize = SubtitleTextPropertiesProvider.Instance.DefaultFontSize;
            cmbFonts.SelectedItem = SubtitleTextPropertiesProvider.Instance.DefaultFontFamily;
            ShadowCheckBox.IsChecked = SubtitleTextPropertiesProvider.Instance.TextShadow == null ? false : true;
        }
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            SubtitleTextPropertiesProvider.Instance.FontSize = (int)inputSize.Value;
            SubtitleTextPropertiesProvider.Instance.TextFontFamily = (FontFamily)cmbFonts.SelectedItem;
            SubtitleTextPropertiesProvider.Instance.Foreground = new SolidColorBrush((Color)textColorPicker.SelectedColor);
            if (ShadowCheckBox.IsChecked == true)
                SubtitleTextPropertiesProvider.Instance.SetTextShadow();
            else
                SubtitleTextPropertiesProvider.Instance.ClearTextShadow();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Visibility = Visibility.Hidden;
        }

        private void ShadowCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            subtitleSettingsViewModel.TextShadow = subtitleSettingsViewModel.DefaultTextShadow;
        }

        private void ShadowCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            subtitleSettingsViewModel.TextShadow = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string filmName = txtMovieName.Text;
            filmName = "\"" + filmName + "\"";
            string language = ((ComboBoxItem)cmbLanguage.SelectedItem).Tag.ToString();
            string arguments = filmName + " " + language;

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string name = "Resources";
            int index = -1;
            while (true)
            {
                index = GetFolderFromFolder(path, name);
                if (index != -1)
                    break;
                path = Directory.GetParent(path).FullName;
            }
            ProcessStartInfo subDownloader = new ProcessStartInfo(path + @"\Resources\Executables\subtitleDownloader.exe");
            subDownloader.Arguments = arguments;
            subDownloader.WindowStyle = ProcessWindowStyle.Hidden;
            var subDownloaderProcess = Process.Start(subDownloader);

            while (!subDownloaderProcess.HasExited) { }

            MessageBox.Show("Subtitle downloaded");

            string subtitleName = GenerateSubName(filmName, language);
            subtitleSettingsViewModel.AddItemToAvailableSubtitles(subtitleName);
        }

        private int GetFolderFromFolder(string path, string folderName)
        {
            var files = Directory.GetDirectories(path);
            for (int i = 0; i < files.Length; i++)
            {
                var currentFolder = files[i].Split('\\');
                var currentFolderName = currentFolder[currentFolder.Length - 1];
                if (currentFolderName == folderName)
                    return i;
            }
            return -1;
        }

        private string GenerateSubName(string name, string lang)
        {
            string subName = name.Trim().ToLower().Substring(1, name.Length - 2).Replace(" ", "-");
            subName = subName + "-" + lang.ToUpper();
            var files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\subtitles");
            foreach (var file in files)
            {
                if (Regex.IsMatch(file, @"^.*" + subName + ".*$"))
                {
                    subName = file;
                    break;
                }

            }
            return subName;
        }
    }
}
