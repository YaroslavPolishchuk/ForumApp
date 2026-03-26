using Forum.Application.Users.Commands;
using Forum.Application.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterUserCommand command)
        {
            Result result = await Mediator.Send(command);
            return result.ToActionResult();            
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginUserCommand command)
        {
            Result<AuthResponse> result = await Mediator.Send(command);
            return result.ToActionResult();            
        }
    }
}
