using evoFlix.FileScanner;
using evoFlix.Models.Content;
using evoFlix.Services.FilmService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.API
{
    public class MethodTest
    {
        static async Task Main(string[] args)
        {
            FileReader fileScanner = new FileReader();
            NewFilmService newFilmService = new NewFilmService();
            newFilmService.DeleteAll();

            OmdbProcessor OmdbProcessor = new OmdbProcessor();


            var LOCAL = fileScanner.ReadAllFiles();

            foreach (var x in LOCAL)
            {
                var outFilm = await OmdbProcessor.Load(x.Key, x.Value);
                FilmSerializable filmSerializable2 = new FilmSerializable(outFilm);
                FilmTableModel testFilm2 = filmSerializable2.ConvertFilmToDB();
                newFilmService.Create(testFilm2);
            }

            var film = await OmdbProcessor.Load("Wolfwalkers", "2020");
            FilmSerializable filmSerializable = new FilmSerializable(film);
            FilmTableModel testFilm = filmSerializable.ConvertFilmToDB();
            newFilmService.Create(testFilm);
            //UpdateFilmTableElements
        }
    }
}
