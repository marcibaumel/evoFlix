using System.Windows.Controls;
using System.Windows;
using evoFlix.Models.Content;
using evoFlix.WPF.ViewModels;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System;



namespace evoFlix.WPF.Views
{

    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            HomeFrame.Content = new FilmListView(HomeFrame);
        }


    }
}
