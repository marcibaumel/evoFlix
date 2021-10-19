using evoFlix.Models.Content;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test.Implementations
{
    /*
     * NEM JÓ, régi
     */
    public class FilmSerializable : IFilmSerializable
    {
        private FilmModel Film { get; set; }

        public FilmSerializable(FilmModel film)
        {
            Film = film;
        }

        public FilmTableModel ConvertFilmToDB()
        {
            var cultureInfo = new CultureInfo("de-DE");
            string[] timeSpanHelper = Film.Runtime.Split(' ');
            double ImdbRating = double.Parse(Film.ImdbRating, System.Globalization.CultureInfo.InvariantCulture);
            

            FilmTableModel newFilm = new FilmTableModel(Film.Title, DateTime.Parse(Film.Released, cultureInfo), Film.Director, Film.Plot, ImdbRating,
                                         TimeSpan.FromMinutes(Int32.Parse(timeSpanHelper[0])), Film.Actors, Film.Poster, giveBackTheRatings(Film.Rated),"");

            return newFilm;

        }

       
        public Ratings giveBackTheRatings(string Type)
        {
            switch (Type)
            {
                case "PG-13":
                    return Ratings.PG13;
                case "N/A":
                    return Ratings.NA;
                case "R":
                    return Ratings.R;
                case "PG":
                    return Ratings.PG;
                default:
                    return Ratings.NA;
            }
        }
    }
}
