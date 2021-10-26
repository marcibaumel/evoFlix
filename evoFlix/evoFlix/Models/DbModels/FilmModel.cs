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
    }

    public enum Ratings
    {
        G,
        PG,
        PG13,
        R,
        NC17
    }
}
