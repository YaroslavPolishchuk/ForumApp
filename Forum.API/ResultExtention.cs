using Forum.Application.Users;
using Forum.Application.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult(this Result result)
        {
            if (result.IsSuccess) return new OkResult();

            return result.Message switch
            {
                PossibleResponse.UserAlreadyExists => new ConflictObjectResult(result.Message.ToString()),
                PossibleResponse.NameAlreadyInUse => new ConflictObjectResult(result.Message.ToString()),
                PossibleResponse.UserNotFound => new NotFoundObjectResult(result.Message.ToString()),
                PossibleResponse.InvalidPassword => new UnauthorizedObjectResult(result.Message.ToString()),
                _ => new BadRequestObjectResult(result.Message.ToString())
            };
        }

        public static ActionResult ToActionResult<T>(this Result<T> result)
        {
            if (result.IsSuccess) return new OkObjectResult(result.Value);

            return result.Message switch
            {
                PossibleResponse.InvalidPassword => new UnauthorizedObjectResult(result.Message.ToString()),
                PossibleResponse.UserNotFound => new NotFoundObjectResult(result.Message.ToString()),
                _ => new BadRequestObjectResult(result.Message.ToString())
            };
        }
    }

}
