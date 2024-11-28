using Microsoft.AspNetCore.Mvc;
using CarRentalSystem.Models;
using CarRentalSystem.Services;

namespace CarRentalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            var registeredUser = await _userService.RegisterUser(user);
            return Ok(registeredUser);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = _userService.AuthenticateUser(user);
            return Ok(new { Token = token });
        }
    }
}
