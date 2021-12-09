using evoFlix.Models;
using System;
using System.Collections.Generic;

namespace evoFlix.Services.FilmService
{
    public interface IFilmServices
    {
        IEnumerable<FilmModel> GetAllFilm();
        void addFilm(FilmModel film);
        void updateFilm(FilmModel film);
        void deletFilmById(Guid id);
        void addFilmByNameAndYear(string title, DateTime time);
    }
}
