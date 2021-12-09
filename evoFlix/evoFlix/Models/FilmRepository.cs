using System;
using System.Collections.Generic;
using System.Linq;

namespace evoFlix.Models
{
    public class FilmRepository : IFilmRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public FilmRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFilm(FilmModel film)
        {
            _unitOfWork.Films.Add(film);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<FilmModel> GetAllFilm()
        {
            return _unitOfWork.Films;
        }

        public bool filmIsInDatabase(FilmModel film)
        {
            FilmModel isInDb = _unitOfWork.Films.Where(filmModel => filmModel.Title == film.Title && filmModel.ReleaseYear == film.ReleaseYear).FirstOrDefault();
            if (isInDb.Equals(null))
            {
                return false;
            }
            return true;
        }
    }
}
