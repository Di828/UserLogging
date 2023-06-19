using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UserLogging.Models.User;
using UserLogging.Services.UserService;

namespace UserLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {        
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<AuthResponse> Register (UserDto request)
        {            
            return await _userService.Register(request);
        }

        [HttpPost("login")]
        public async Task<AuthResponse> Login (UserDto request)
        {
            return await _userService.Login(request);
        }
    }
}
