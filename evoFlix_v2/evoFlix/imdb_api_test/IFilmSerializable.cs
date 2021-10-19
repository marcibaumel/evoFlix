using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoFlix.Models.Content;

namespace imdb_api_test
{
    public interface IFilmSerializable
    {
        FilmTableModel ConvertFilmToDB();
    }
}
