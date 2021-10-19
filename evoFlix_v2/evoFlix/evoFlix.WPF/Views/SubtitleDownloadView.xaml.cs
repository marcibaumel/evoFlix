﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for SubtitleDownloadView.xaml
    /// </summary>
    public partial class SubtitleDownloadView : UserControl
    {
        public SubtitleDownloadView()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            string name = inputName.Text;
            string lang = (string)inputLang.SelectedItem;
            MessageBox.Show(lang);
            //var process = Process.Start(new ProcessStartInfo
            //{
            //    Arguments = "HelloWorld.py",
            //    FileName = "python",
            //    UseShellExecute = false,
            //    RedirectStandardOutput = true
            //});
        }
    }
}
