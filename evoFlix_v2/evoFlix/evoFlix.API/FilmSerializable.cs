using evoFlix.Models.Content;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.API
{
    public class FilmSerializable
    {
        private FilmModel Film { get; set; }

        public FilmSerializable(FilmModel film)
        {
            Film = film;
        }

        public FilmSerializable()
        {
            
        }

        public FilmTableModel ConvertFilmToDB()
        {
            var cultureInfo = new CultureInfo("de-DE");
            string[] timeSpanHelper = Film.Runtime.Split(' ');
           
            
            double ImdbRating = double.Parse(Film.ImdbRating, System.Globalization.CultureInfo.InvariantCulture);
            string Source = setFilmSource(Film.Title, DateTime.Parse(Film.Released, cultureInfo).Year.ToString());

            FilmTableModel newFilm = new FilmTableModel(Film.Title, DateTime.Parse(Film.Released, cultureInfo), Film.Director, Film.Plot, ImdbRating,
                                         TimeSpan.FromMinutes(Int32.Parse(timeSpanHelper[0])), Film.Actors, Film.Poster, giveBackTheRatings(Film.Rated), Source);

            return newFilm;
        }

        public string setFilmSource(string FilmName, string FilmYear)
        {
            string path = @"imdb_api_test/Content";
            string fullPath = Path.GetFullPath(path);

            string[] stringSeperators = new string[] { "bin" };
            string[] folderName = fullPath.Split(stringSeperators, StringSplitOptions.None);
            string convertFolder = folderName[0] + "\\Content";
            fullPath = convertFolder;

            string[] files = Directory.GetFiles(fullPath);

            if (FilmName.Length < 15) 
            { 
                FilmName = FilmName.Replace(" ", "_"); 
            }
            else 
            { 
                FilmName = FilmName.Replace(" ", "_").Substring(0, 15); 
            }
            
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Contains(FilmName))
                {
                    return files[i];
                }
            }
            return "";
        }


        public Ratings giveBackTheRatings(string Type)
        {
            switch (Type)
            {
                case "PG-13":
                    return Ratings.PG13;
                    break;
                case "N/A":
                    return Ratings.NA;
                    break;
                case "R":
                    return Ratings.R;
                    break;
                case "PG":
                    return Ratings.PG;
                    break;

                default:
                    return Ratings.NA;
                    break;
            }
        }
    }
}
