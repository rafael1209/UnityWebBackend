using Microsoft.AspNetCore.Mvc;

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
                public IActionResult Register()
                {
                        return Ok();
                }
        }
}
