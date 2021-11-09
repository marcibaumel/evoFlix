using Microsoft.AspNetCore.Mvc;

namespace evoFlix.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            var headers = HttpContext.Request.Headers;

            return Ok();
        }
    }
}
