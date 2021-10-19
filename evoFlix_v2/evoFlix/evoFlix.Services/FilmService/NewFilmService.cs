using evoFlix.DataAccess;
using evoFlix.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services.FilmService
{
    public class NewFilmService
    {
        private UnitOfWork unitOfWork;

        public NewFilmService()
        {
            unitOfWork = new UnitOfWork();
        }

        public void Create(FilmTableModel givenFilm)
        {
            
            if (IsUniqueFilm(givenFilm))
            {
                foreach(FilmTableModel film in unitOfWork.Films)
                {
                    givenFilm.ID = film.ID;
                    var test = film.Equals(givenFilm);

                    if (film.Title.Equals(givenFilm.Title) && !CompareToObject(givenFilm, film))
                    {
                        unitOfWork.Films.Remove(film);
                        unitOfWork.Films.Add(givenFilm);
                    }
                } 
            }
            else { unitOfWork.Films.Add(givenFilm); }

            unitOfWork.SaveChanges();
        }

        public bool IsUniqueFilm(FilmTableModel givenFilm)
        {
            var query = (from film in unitOfWork.Films
                         where film.Title == givenFilm.Title &&
                         film.ReleaseYear == givenFilm.ReleaseYear &&
                         film.Poster == givenFilm.Poster &&
                         film.Source == givenFilm.Source
                         select film
                         ).Any();

            return query;
        }

        public bool CompareToObject(FilmTableModel film1, FilmTableModel film2)
        {
            if(
                film1.Title.Equals(film2.Title) &&
                film1.Rated.Equals(film2.Rated) &&
                film1.Poster.Equals(film2.Poster) &&
                film1.Source.Equals(film2.Source) &&
                film1.ReleaseYear.Equals(film2.ReleaseYear)
            )
            {
                return true;
            }
            return false;
            
        }

        public void DeleteAll()
        {
            foreach(FilmTableModel film in unitOfWork.Films)
            {
                unitOfWork.Films.Remove(film);
            }
            unitOfWork.SaveChanges();
        }

      }
}
