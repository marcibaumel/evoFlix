using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace imdb_api_test
{
    
    
    class OmdbDemo
    {
        static void Main(string[] args)
        {
            string apiKey = "f51c1d39";
            //string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string year = "2020";
            string name = "wolfwalkers";
            string type = "movie";
            string plot = "full";
           

            var sb = new StringBuilder(baseUri);
            sb.Append($"&t={name}");
            sb.Append($"&y={year}");
            sb.Append($"&type={type}");
            sb.Append($"&plot={plot}");

            Console.WriteLine(sb);
            var sb2 = "http://www.omdbapi.com/?apikey=f51c1d39&t=wolfwalkers&y=2020&plot=full";

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
            
            Console.WriteLine(result);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
    

    

}
