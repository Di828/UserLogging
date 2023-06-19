using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserLogging.Models.PossibleActions;
using UserLogging.Services.UserService;

namespace UserLogging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthTestsController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthTestsController(IUserService userService)
        {            
            _userService = userService;
        }

        [HttpGet("TokenDataTest")]
        public async Task<PossibleAction[]> AuthTesting()
        {
            return await _userService.GetUserActions();
        }
    }
}
