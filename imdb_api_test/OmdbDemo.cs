using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    class OmdbDemo
    {
        static void Main(string[] args)
        {
            string apiKey = "f51c1d39";
            string baseUri = $"http://www.omdbapi.com/?apikey={apiKey}";

            string name = "wolfwalkers";
            string type = "movie";

            var sb = new StringBuilder(baseUri);
            sb.Append($"&s={name}");
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

            Console.WriteLine(result);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
