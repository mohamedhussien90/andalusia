using Assignment_8.Services;
using Microsoft.AspNetCore.Mvc;
using static Assignment_8.Models.AuthDTOs;

namespace Assignment_8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (!_authService.Register(request)) return Conflict("User already exists.");
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _authService.Login(request);
            if (token == null) return Unauthorized("Invalid credentials.");
            return Ok(new { Token = token });
        }
    }
}
