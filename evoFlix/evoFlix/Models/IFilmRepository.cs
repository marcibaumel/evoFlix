using System;
using System.Collections.Generic;

namespace evoFlix.Models
{
    public interface IFilmRepository
    {
        IEnumerable<FilmModel> GetAllFilm();
        void AddFilm(FilmModel film);
        bool filmIsInDatabase(FilmModel film);
    }
}
