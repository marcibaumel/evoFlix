﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            
            FilmClass testConvert = JsonConvert.DeserializeObject<FilmClass>(result);

            Console.WriteLine(testConvert.ToString());
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }

  



}
