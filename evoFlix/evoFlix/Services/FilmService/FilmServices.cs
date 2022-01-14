using evoFlix.Models;
using System;
using System.Collections.Generic;

namespace evoFlix.Services.FilmService
{
    public class FilmServices : IFilmServices
    {
        private readonly IFilmRepository _filmRepository;

        public FilmServices(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public void AddFilm(FilmModel film)
        {
            if (!_filmRepository.filmIsInDatabase(film)){
                _filmRepository.AddFilm(film);
            }
            
        }

        public void AddFilmByNameAndYear(string title, DateTime time)
        {
            throw new NotImplementedException();
        }

        public void DeletFilmById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FilmModel> GetAllFilm()
        {
            return _filmRepository.GetAllFilm();
        }

        public void UpdateFilm(FilmModel film)
        {
            throw new NotImplementedException();
        }
    }
}
