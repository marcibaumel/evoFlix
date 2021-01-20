using System;
using System.IO;
using System.Net;
using System.Text;
using evoFlix.Services;
using evoFlix.Models;
using Newtonsoft.Json;
using evoFlix.Models.Content;

namespace imdb_api_test
{



    public partial class OmdbDemo
    {

       
        

        static void Main(string[] args)
        {
            FilmService fS = new FilmService();
            MyListService wS = new MyListService();

            string apiKey = "f51c1d39";
            //string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string year = "2010";
            string name = "Inception";
            
            
            string type = "movie";
           
           
         

            var sb = new StringBuilder(baseUri);

            sb.Append($"&t={name}");
            sb.Append($"&y={year}");
            sb.Append($"&type={type}");
            
            
            var request = WebRequest.Create(sb.ToString());
            request.Timeout = 1000;
            request.Method = "GET";
            request.ContentType = "application/json";

            string result = string.Empty;
           
            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            //Console.WriteLine(result);
            
            Film testConvert = JsonConvert.DeserializeObject<Film>(result);

            //fS.setSource("wolfwalkers", @"D:\WORK\EGYETEM\3 FÉLÉV\EvoCampus\imdb_api_test\Content\wolfwalkers_2020.mp4");

            //if (fS.IsUniqueFilmTitle(testConvert.Title) == true)
            //{
            //    fS.AddFilm(testConvert);
            //}
            //else
            //{
            //    Console.WriteLine("Hiba a DB-be");
            //}

            wS.AddToMyList(1, 5);

            Console.WriteLine(testConvert.ToString());
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

  



}
