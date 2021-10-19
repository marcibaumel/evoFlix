using evoFlix.Models.Content;
using evoFlix.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;



namespace evoFlix.WPF.Views
{
    public partial class FilmDetailsView : UserControl
    {
        private readonly Frame frame;
        private readonly FilmDetailsViewModel filmDetailsViewModel;
        public FilmDetailsView(Frame frame, FilmTableModel film)
        {
            InitializeComponent();

            this.frame = frame;
            filmDetailsViewModel = new FilmDetailsViewModel(film);
            DataContext = filmDetailsViewModel;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            frame.GoBack();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            var videoPlayer = new VideoPlayerWindow(filmDetailsViewModel.Film, 0);
            videoPlayer.Show();
            videoPlayer.Focus();
            videoPlayer.WindowState = WindowState.Maximized;

        }

        //NOT IMPLEMENTED
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
