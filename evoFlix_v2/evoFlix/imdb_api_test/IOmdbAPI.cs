using evoFlix.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    public interface IOmdbAPI
    {
        string GetOmdbData();

        FilmModel JsonConvertByResult(string Result);
    }
}
