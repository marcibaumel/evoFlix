using evoFlix.Models;
using evoFlix.Services.FilmService;
using Microsoft.AspNetCore.Mvc;


namespace evoFlix.Controllers
{
    [Route("[controller]")]

    public class FilmController : Controller
    {
        private readonly IFilmServices _filmServices;

        public FilmController(IFilmServices filmServices)
        {
            _filmServices = filmServices;
        }
        
        [HttpGet("getAllFilm")]
        public IActionResult GetAllFilm()
        {
            return Ok(_filmServices.GetAllFilm());
        }

        [HttpPost("addFilm")]
        public IActionResult AddFilm([FromBody] FilmModel filmModel)
        {
            _filmServices.AddFilm(filmModel);
            return Created("", filmModel);
        }
        
    }
}
