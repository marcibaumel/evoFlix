using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.API
{
    public class FilmModel
    {
        public string Title { get; set; }
        public string Released { get; set; }
        public string Plot { get; set; }
        public string Director { get; set; }
        public string ImdbRating { get; set; }
        public string Runtime { get; set; }
        public string Actors { get; set; }
        public string Poster { get; set; }
        public string Rated { get; set; }

        public string Source { get; set; }

        public FilmModel(string title, string year, string plot, string director, string imdbRating, string runtime, string actors)
        {
            Title = title;
            Released = year;
            Plot = plot;
            Director = director;
            ImdbRating = imdbRating;
            Runtime = runtime;
            Actors = actors;
        }

        public override string ToString()
        {
            return "Title: " + Title + "\nDirector: " + Director + "\n ImdbRating:" + ImdbRating + "\n\n";
        }

        public FilmModel() { }
    }
}
