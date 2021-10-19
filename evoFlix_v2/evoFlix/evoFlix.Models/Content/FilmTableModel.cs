using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Content
{
    [Table("FilmTable")]
    public class FilmTableModel : BaseTableModel
    {
        public string Title { get; set; }

        public DateTime ReleaseYear { get; set; }

        public string DirectorName { get; set; }

        public string Plot { get; set; }

        public double ImdbRating { get; set; }
        
        public TimeSpan RunTime { get; set; }

        public string Actors { get; set; }

        public string Poster { get; set; }

        public Ratings Rated { get; set; }
        public String Source { get; set; }

        public FilmTableModel(string title, DateTime releaseYear, string directorName, string plot, double imdbRating, TimeSpan runTime, string actors, string poster, Ratings rated, string source)
        {
            Title = title;
            ReleaseYear = releaseYear;
            DirectorName = directorName;
            Plot = plot;
            ImdbRating = imdbRating;
            RunTime = runTime;
            Actors = actors;
            Poster = poster;
            Rated = rated;
            Source = source;
        }

        public FilmTableModel()
        {

        }

       
    }


    public enum Ratings
    {
        PG,
        PG13,
        R,
        NC17,
        Passed,
        NA
    }
}