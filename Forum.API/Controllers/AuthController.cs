using Forum.Application.Users;
using Forum.Application.Users.Commands;
using Forum.Application.Users.Models;
using Forum.Infrastructure.Identity.Token;
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
            var result = await Mediator.Send(command);

            return result switch
            {
                IdentityStatus.Success => Ok(new { message = "Registered sucessfull" }),
                IdentityStatus.UserAlreadyExists => Conflict(new { message = "This email is already registered" }),
                IdentityStatus.NameAlreadyInUse => Conflict(new { message = "This name is already in use" }),
                _ => StatusCode(500, new { message = "An unexpected error occurred." })
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> LogIn([FromBody] LoginUserCommand command)
        {
            var result = await Mediator.Send(command);

            return null;
            //return result switch
            //{
            //    IdentityStatus.Success => Ok(JwtProvider.GenerateToken(null)),
            //    IdentityStatus.UserNotFound => Unauthorized("User not found."),
            //    IdentityStatus.InvalidPassword => Unauthorized("Invalid password."),
            //    _ => StatusCode(500, "An unexpected error occurred.")
            //};
        }
    }
}
