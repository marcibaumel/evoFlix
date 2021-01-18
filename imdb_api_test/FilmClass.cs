using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    public class FilmClass
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

        public override string ToString()
        {
            return Title+ "\n\n" + Year+ "\n\n" + Plot + "\n\n" + Director + "\n\n" + imdbRating + "\n\n" + Runtime + "\n\n" + Rated + "\n\n" + Actors + "\n\n" + Poster;
        }

    }

}


