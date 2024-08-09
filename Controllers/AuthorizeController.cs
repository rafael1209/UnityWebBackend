using Microsoft.AspNetCore.Mvc;
using UnityWebCore.Models.Auth;

namespace UnityWebCore.Controllers
{
        [Route("api/auth")]
        [ApiController]
        public class AuthorizeController : Controller
        {
                public AuthorizeController()
                {

                }

                [HttpPost("register")]
                public IActionResult Register(RegisterRequest registerRequest)
                {
                        return Ok("Success");
                }
        }
}
