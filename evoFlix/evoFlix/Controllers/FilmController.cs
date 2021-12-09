using evoFlix.Services.FilmService;
using Microsoft.AspNetCore.Mvc;


namespace evoFlix.Controllers
{
    [Route("[controller]")]
    public class FilmController:Controller
    {
        private readonly IFilmServices _filmServices;

        public FilmController(IFilmServices filmServices)
        {
            _filmServices = filmServices;
        }


    }
}
