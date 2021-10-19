using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.API
{
    public class OmdbProcessor
    { 
        private readonly string APIKEY = "f51c1d39";
        
        /*
        public readonly string APIKEY;

        public sealed class MyServiceConfiguration
        {
            public readonly string ApiKey;

            public MyServiceConfiguration(string apiKey)
            {
                if (string.IsNullOrEmpty(apiKey)) throw new ArgumentException();
                this.ApiKey = apiKey;
            }
        }
        */

        public async Task<FilmModel> Load(string Title, string Year)
        {
            string url = $"http://www.omdbapi.com/?apikey={APIKEY}&t={Title}&y={Year}";
            ApiHelper.InitializeClient();



            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    FilmModel film = await response.Content.ReadAsAsync<FilmModel>();

                    return film;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        private HttpClient restClient = new HttpClient(new HttpClientHandler());
        private string URI = "http://www.omdbapi.com/?apikey={APIKEY}&t=Wolfwalkers&y=2020";
        public async Task<string> testRequest(HttpClient httpClient)
        {

            var Builder = new System.UriBuilder(URI);
            var response = await httpClient.GetAsync(Builder.Uri);
            var context = await response.Content.ReadAsStringAsync();

            return context;
        }
    }
}
