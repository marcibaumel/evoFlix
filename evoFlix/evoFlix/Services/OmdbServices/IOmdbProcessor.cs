using System.Threading.Tasks;

namespace evoFlix.Services.OmdbServices
{
    public interface IOmdbProcessor
    {
        public Task<FilmDto> GetFilmByOmdbApi(string Title, string Year);
    }
}
