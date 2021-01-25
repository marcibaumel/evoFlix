using System;
using System.IO;
using System.Net;
using System.Text;
using evoFlix.Services;
using evoFlix.Models;
using Newtonsoft.Json;
using evoFlix.Models.Content;
using System.Reflection;
using System.Linq;
using System.Diagnostics;

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


            string year = "1972";
            string name = "The Godfather";


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


           
            //string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\Content\";
            //string[] files = Directory.GetFiles(folder);





            ////for (int i = 0; i < files.Length; i++)
            ////{
            ////    Console.WriteLine(files[i]);
            ////}

            
            ////for(int i=0; i<fS.listOfFilms().Count(); i++)
            ////{

            ////}

            //string title = "coco";
            //fS.setSource(title, files[0]);

            //if (fS.IsUniqueFilmTitle(testConvert.Title) == true)
            //{
            //    fS.AddFilm(testConvert);
            //}
            //else
            //{
            //    Console.WriteLine("Hiba a DB-be");
            //}


            wS.AddToMyList(2, 5);

            //Console.WriteLine(testConvert.ToString());

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }


    }
    static class Helper
    {
        public static string GetUntilOrEmpty(this string text, string stopAt = "_")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }

}


