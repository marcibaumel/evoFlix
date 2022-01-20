using evoFlix.Models;
using System.Threading.Tasks;

namespace evoFlix.Services.OmdbServices
{
    public interface IOmdbProcessor
    {
        Task<FilmDto> GetFilmByOmdbApi(string Title, string Year);
        FilmModel ConvetToModel(FilmDto filmDto);
        string setFilmSource(string FilmName, string FilmYear);
        Ratings giveBackTheRatings(string Type);

    }
}
