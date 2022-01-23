using evoFlix.Models;
using evoFlix.Services.FilmService;
using evoFlix.Services.OmdbServices;
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

        [HttpGet("getFilmActors")]
        public string getOmdbDataActors(string title, string year)
        {
            return _filmServices.getDataFromOmdb(title, year).Actors;
        }

        [HttpPost("saveFilm")]
        public IActionResult saveFilm(string title, string year)
        {
            FilmDto filmDto = _filmServices.getDataFromOmdb(title, year);
            FilmModel filmModel = _filmServices.getFilmModelFromFilmDto(filmDto);
            _filmServices.AddFilm(filmModel);
            return Created("", filmModel);
        }

        [HttpPost("addFilm")]
        public IActionResult AddFilm([FromBody] FilmModel filmModel)
        {
            _filmServices.AddFilm(filmModel);
            return Created("", filmModel);
        }
        
    }
}
