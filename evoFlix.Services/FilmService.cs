using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using evoFlix.Models.Content;

namespace evoFlix.Services
{
    public class FilmService
    {
        private UnitOfWork unitOfWork;
        
        

        public FilmService()
        {
            unitOfWork = new UnitOfWork();
        }


        public void AddFilm(Film film)
        {
            unitOfWork.Films.Add(film);
            unitOfWork.SaveChanges();
        }

        public bool IsUniqueFilmTitle(string title)
        {
            foreach (Film film in unitOfWork.Films)
                if (film.Title == title)
                    return false;
            return true;
        }

        public List<int> listOfFilms()
        {
            List<int> ListOfFilms = new List<int>();

            foreach (var film in unitOfWork.Films)
            {
                ListOfFilms.Add(film.Id);
            }

            return ListOfFilms;
        }



        public string getFilmTitle(int Number)
        {
            string filmTitle = unitOfWork.Films.FirstOrDefault(x => x.Id == Number).Title;
            if (filmTitle == null)
            {
                return "Failed";
            }

            return filmTitle.ToString();
        }

        public void setSource(string Title, string source)
        {
            var filmTitle = unitOfWork.Films.FirstOrDefault(x => x.Title == Title);

            if (filmTitle != null)
            {
                filmTitle.Source = source;

                unitOfWork.SaveChanges();
            }
                
        }

        public string getPoster(string Title)
        {
            var filmPoster = unitOfWork.Films.FirstOrDefault(x => x.Title==Title).Poster;
            if (filmPoster == null)
            {
                return "Failed";
            }

            return filmPoster.ToString();
        }

        public string getPlot(string Title)
        {
            var filmPlot = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Plot;
            if (filmPlot == null)
            {
                return "Failed";
            }

            return filmPlot.ToString();
        }

        public string getYear(string Title)
        {
            var filmYear = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Year;
            if (filmYear == null)
            {
                return "Failed";
            }

            return filmYear.ToString();
        }

        public string getDirector(string Title)
        {
            var filmDirector = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Director;
            if (filmDirector == null)
            {
                return "Failed";
            }

            return filmDirector.ToString();
        }

        public string getRating(string Title)
        {
            var filmRating = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).imdbRating;
            if (filmRating == null)
            {
                return "Failed";
            }

            return filmRating.ToString();
        }

        public string getActors(string Title)
        {
            var filmActors = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Actors;
            if (filmActors == null)
            {
                return "Failed";
            }

            return filmActors.ToString();
        }

        public string getRated(string Title)
        {
            var filmRated = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Rated;
            if (filmRated == null)
            {
                return "Failed";
            }

            return filmRated.ToString();
        }

        public string getRuntime(string Title)
        {
            var filmRuntime = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Runtime;
            if (filmRuntime == null)
            {
                return "Failed";
            }

            return filmRuntime.ToString();
        }

        public string get(string Title)
        {
            var filmSource = unitOfWork.Films.FirstOrDefault(x => x.Title == Title).Source;
            if (filmSource == null)
            {
                return "Failed";
            }

            return filmSource.ToString();
        }

        public Film getFilm(string Title)
        {
            Film film = unitOfWork.Films.FirstOrDefault(x => x.Title == Title);
            return film;
        }





    }
}
