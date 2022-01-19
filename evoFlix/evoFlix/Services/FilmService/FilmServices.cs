using evoFlix.Models;
using evoFlix.Services.OmdbServices;
using System;
using System.Collections.Generic;

namespace evoFlix.Services.FilmService
{
    public class FilmServices : IFilmServices
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IOmdbProcessor _omdbProcessor;

        public FilmServices(IFilmRepository filmRepository, IOmdbProcessor omdbProcessor)
        {
            _filmRepository = filmRepository;
            _omdbProcessor = omdbProcessor;
        }

        public string getDataFromOmdb(string title, string year)
        {
            return _omdbProcessor.GetFilmByOmdbApi(title, year).Result.Actors;
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
