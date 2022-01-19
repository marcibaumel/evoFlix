using evoFlix.Models;
using System;
using System.Collections.Generic;

namespace evoFlix.Services.FilmService
{
    public interface IFilmServices
    {
        IEnumerable<FilmModel> GetAllFilm();
        void AddFilm(FilmModel film);
        void UpdateFilm(FilmModel film);
        void DeletFilmById(Guid id);
        void AddFilmByNameAndYear(string title, DateTime time);
        string getDataFromOmdb(string title, string year);
    }
}
