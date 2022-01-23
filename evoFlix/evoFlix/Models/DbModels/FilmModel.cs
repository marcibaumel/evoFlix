using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Models
{
    [Table("FilmTable")]
    public class FilmModel
    {
        //TODO
        //-Source

        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleaseYear { get; set; }

        public Ratings Rated { get; set; }

        public TimeSpan RunTime { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string DirectorName { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Genre { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Actors { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string Plot { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public String Poster { get; set; }

        public double ImdbRating { get; set; }


        public FilmModel(Guid id, string title, DateTime releaseYear, Ratings rated, TimeSpan runTime, string directorName, string genre, string actors, string plot, string poster, double imdbRating)
        {
            Id = id;
            Title = title;
            ReleaseYear = releaseYear;
            Rated = rated;
            RunTime = runTime;
            DirectorName = directorName;
            Genre = genre;
            Actors = actors;
            Plot = plot;
            Poster = poster;
            ImdbRating = imdbRating;
        }

    }

    


    public enum Ratings
    {
        G,
        PG,
        PG13,
        R,
        NC17,
        NA
    }
}
