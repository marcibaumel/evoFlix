using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using evoFlix.Models;
using evoFlix.Services.OmdbServices;

namespace evoFlix.Services.OmdbServices
{
    public class OmdbProcessor : IOmdbProcessor
    {

        //TODO:
        //-appsetting-ből olvasni az apikey-t

        private string APIKEY = "f51c1d39";


        public async Task<FilmDto> GetFilmByOmdbApi(string Title, string Year)
        {
            string url = $"http://www.omdbapi.com/?apikey={APIKEY}&t={Title}&y={Year}";
            ApiHelper.InitializeClient();



            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    FilmDto film = await response.Content.ReadAsAsync<FilmDto>();

                    return film;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public FilmModel ConvetToModel(FilmDto filmDto)
        {
            var cultureInfo = new CultureInfo("de-DE");
            string[] timeSpanHelper = filmDto.Runtime.Split(' ');


            double ImdbRating = double.Parse(filmDto.ImdbRating, System.Globalization.CultureInfo.InvariantCulture);
            //string Source = setFilmSource(filmDto.Title, DateTime.Parse(filmDto.Released, cultureInfo).Year.ToString());

            FilmModel newFilm = new FilmModel(new Guid(), filmDto.Title, DateTime.Parse(filmDto.Released, cultureInfo), giveBackTheRatings(filmDto.Rated), TimeSpan.FromMinutes(Int32.Parse(timeSpanHelper[0])),
                                            filmDto.Director, filmDto.Genre, filmDto.Actors, filmDto.Plot, filmDto.Poster, ImdbRating);

            return newFilm;
        }

        

        public Ratings giveBackTheRatings(string Type)
        {
            switch (Type)
            {
                case "PG-13":
                    return Ratings.PG13;
                case "N/A":
                    return Ratings.NA;
                case "R":
                    return Ratings.R;
                case "PG":
                    return Ratings.PG;

                default:
                    return Ratings.NA;
            }
        }
        
    }
}