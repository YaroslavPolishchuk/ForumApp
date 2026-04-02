using Forum.Application.Common.Mapping;
using Forum.Application.Messages.Commands.CreateMessage;
using Forum.Application.Messages.Commands.UpdateMessage;
using Forum.Application.Messages.Commands.DeleteMessage;
using Forum.Application.Messages.Queries.GetMessages;
using Forum.Application.Users.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMessages([FromQuery] int topicId)
        {
            Result<IEnumerable<MessageMappingExtension.MessageDto>> result = await Mediator.Send(new GetMessagesByTopicIdQuery(topicId));
            return result.ToActionResult();
        }

        [HttpPost]
        public async Task<int> CreateMessage([FromBody] CreateMessageCommand command)
            => await Mediator.Send(command);

        [HttpPut]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await Mediator.Send(new DeleteMessageCommand(id));
            return Ok();
        }
    }
}
