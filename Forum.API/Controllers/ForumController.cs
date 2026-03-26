using Forum.Application.Common.Mapping;
using Forum.Application.Forums.Commands.CreateBoard;
using Forum.Application.Forums.Queries.GetBoard;
using Forum.Application.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ApiControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetForums()
        {
            Result<IEnumerable<ForumMappingExtension.ForumDto>> result = await Mediator.Send(new GetForumsQuery());
            return result.ToActionResult();
        }

        [HttpPost]
        [Authorize(Roles = "registered,admin")]
        public async Task<int> CreateForum(CreateBoardCommand command)
            => await Mediator.Send(command);
    }
}
