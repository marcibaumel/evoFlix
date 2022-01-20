using evoFlix.Models;
using evoFlix.Services.OmdbServices;
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
        FilmDto getDataFromOmdb(string title, string year);
        FilmModel getFilmModelFromFilmDto(FilmDto filmDto);
    }
}
