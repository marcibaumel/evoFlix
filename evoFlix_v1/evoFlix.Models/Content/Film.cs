using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Models.Content
{
    public class Film:BaseModel
    {

        public String Title { get; set; }
        public String Year { get; set; }

        public String Plot { get; set; }

        public String Director { get; set; }

        public String imdbRating { get; set; }
        public String Runtime { get; set; }

        public String Rated { get; set; }

        public String Actors { get; set; }

        public String Poster { get; set; }

        public String Source { get; set; }

    }
}
