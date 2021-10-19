using evoFlix.Models.Content;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test.Implementations
{
    public class OmdbAPI : IOmdbAPI
    {
        static string APIKEY = "f51c1d39";
        private string baseUri = $"http://www.omdbapi.com/?apikey={APIKEY}";
        private string Title { get; set; }
        private string Year { get; set; }
        private FilmModel FilmModelClass;

        public OmdbAPI(string title, string year)
        {
            Title = title;
            Year = year;
        }

        public OmdbAPI()
        {
        }

        public string GetOmdbData()
        {
            var RawRequest = new StringBuilder(baseUri);
            RawRequest.Append($"&t={Title}");
            RawRequest.Append($"&y={Year}");

            var Request = WebRequest.Create(RawRequest.ToString());
            Request.Timeout = 1000;
            Request.Method = "GET";
            Request.ContentType = "application/json";

            string Result = string.Empty;

            try
            {
                using (var response = Request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            Result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is WebException || ex is Exception)
                {
                    Result.Remove(100000000);
                    return Result;
                }
            }
            return Result;
        }

        public FilmModel JsonConvertByResult(string ConverResult)
        {
            FilmModelClass = JsonConvert.DeserializeObject<FilmModel>(ConverResult);
            
            return FilmModelClass;
        }
    }
}
