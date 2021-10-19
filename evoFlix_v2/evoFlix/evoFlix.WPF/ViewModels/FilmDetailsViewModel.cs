using evoFlix.Models.Content;
using System;
using System.Windows.Media.Imaging;



namespace evoFlix.WPF.ViewModels
{
    public class FilmDetailsViewModel
    {
        public FilmTableModel Film { get; set; }
        public BitmapImage Poster { get; set; }
        public bool SourceIsEmpty { get; set; }

        public FilmDetailsViewModel(FilmTableModel film)
        {
            Film = film;
            Poster = new BitmapImage(new Uri(film.Poster, UriKind.Absolute));
            SourceIsEmpty = film.Source == "" ? false : true;
        }
    }
}
