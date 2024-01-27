using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersManagerApi.Models;
using UsersManagerApi.Services;

namespace UsersManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _authServices;

        public AuthController(AuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<AuthResponse> Authenticate([FromBody] AuthCredentials credentials)
        {
            var result = _authServices.Authenticate(credentials);

            if (result == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            return result;
        }
    }
}
