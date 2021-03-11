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
    public class FilmTableModel:BaseModel
    {
        [Key]
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }

        public string DirectorName { get; set; }

        public string Plot { get; set; }

        public string ImdbRating { get; set; }
        public string RunTime { get; set; }

        public string Actors { get; set; }

        public string Poster { get; set; }

        public string Rated { get; set; }



    }
}
