using Microsoft.AspNetCore.Mvc;
using ClientRecordsAPI.Services;
using ClientRecordsAPI.DTOs;

namespace ClientRecordsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = _jwtService.GenerateToken("1", "Admin");
                return Ok(new LoginResponseDto { Token = token });

            }

            return Unauthorized("Invalid credentials");
        }
    }


}
