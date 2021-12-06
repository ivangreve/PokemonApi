using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challenge.Contracts.Requests;
using Challenge.Services;
using Microsoft.AspNetCore.Authorization;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationService _authorizationService;

        public AuthController(IJwtAuthenticationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthDto user)
        {
            var token = _authorizationService.Authenticate(user.Username, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

    }
}
