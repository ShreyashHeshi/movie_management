using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.DTOs.User;
using Movie.API.Services;

namespace Movie.API.Controllers
{

     [Route("api/[controller]")]
     [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //[HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }
    }
}
