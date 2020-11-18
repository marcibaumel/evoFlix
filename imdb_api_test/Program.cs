using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    class Program
    {
        
        public void Main(string[] args)
        {
            var apiLib = new ApiLib("API-Key");
            //var apiLib = new ApiLib("API_Key");
            //var data = await apiLib.SearchMovieAsync("leon the professional 1994");
        }

        
    }
}
