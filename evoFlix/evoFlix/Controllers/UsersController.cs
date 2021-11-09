using evoFlix.Dtos;
using evoFlix.Models;
using evoFlix.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _services;

        public UsersController(IUserRepository userRepository, IUserServices services)
        {
            _userRepository = userRepository;
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_userRepository.GetAllUser());
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto register)
        {
            if (!_services.UsernameIsValid(register.Username))
                return BadRequest("Username alredy exists.");

            if (!_services.PasswordIsStrong(register.Password))
                return BadRequest("Weak password.");

            var user = new UserModel
            {
                UserId = Guid.NewGuid(),
                Username = register.Username,
                Email = register.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password),
                Birthday = register.Birthday,
                ValidAccount = true,
                CreatedDate = DateTime.Now
            };

            _userRepository.CreateUser(user);

            // missing URI
            return Created("", user);
        }
    }
}
