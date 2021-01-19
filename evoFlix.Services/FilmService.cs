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



        public Film getFilm(string Title)
        {
            Film film = unitOfWork.Films.FirstOrDefault(x => x.Title == Title);
            return film;
        }





    }
}
