using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
    }
}