using evoFlix.Dtos;
using evoFlix.Models;
using evoFlix.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace evoFlix.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserServices _services;
        private readonly IJwtService _jwtService;

        public UsersController(IUserRepository userRepository, IUserServices services, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _services = services;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            return Ok(_userRepository.GetAllUser());
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto registerData)
        {
            if (!_services.UsernameIsValid(registerData.Username))
                return BadRequest("Username alredy exists.");

            if (!_services.PasswordIsStrong(registerData.Password))
                return BadRequest("Weak password.");

            var user = new UserModel
            {
                UserId = Guid.NewGuid(),
                Username = registerData.Username,
                Email = registerData.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerData.Password),
                Birthday = registerData.Birthday,
                ValidAccount = true,
                CreatedDate = DateTime.Now
            };

            _userRepository.CreateUser(user);

            // missing URI
            return Created("", user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginDto loginData)
        {
            var user = _userRepository.GetUserByUsername(loginData.Username);

            if (user == null)
                return BadRequest("User not found");

            if (BCrypt.Net.BCrypt.Verify(loginData.Password, user.Password))
                return BadRequest("Wrong password");

            var token = _jwtService.Generate(user.UserId);

            Response.Cookies.Append("jwt", token, new CookieOptions { HttpOnly = true });

            return Ok("logged in successfully");
        }

        [HttpGet("user")]
        public IActionResult GetUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = token.Issuer;

                var user = _userRepository.GetUserById(userId);

                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
