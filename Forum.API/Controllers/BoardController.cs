using Forum.Application.Forums.Commands.CreateBoard;
using Forum.Application.Forums.Models;
using Forum.Application.Forums.Queries.GetBoard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Forum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardController : ApiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardListDto>>> GetForums()
        {
            await Mediator.Send(new GetBoardListQuery());
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "registered,admin")]
        public async Task<int> CreateForum(CreateBoardCommand command)
            => await Mediator.Send(command);
    }
}
