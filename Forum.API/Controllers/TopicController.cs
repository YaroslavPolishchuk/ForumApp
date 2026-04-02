using Forum.Application.Common.Mapping;
using Forum.Application.Topics.Commands.CreateTopic;
using Forum.Application.Topics.Queries.GetTopics;
using Forum.Application.Users.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicController : ApiControllerBase
    {
        [HttpGet("{forumId}")]
        public async Task<IActionResult> GetTopics(int forumId)
        {
            Result<IEnumerable<TopicMappingExtension.TopicDto>> result = await Mediator.Send(new GetTopicsByForumIdQuery(forumId));
            return result.ToActionResult();
        }

        [HttpPost]
        //[Authorize(Roles = "registered,admin")]
        public async Task<int> CreateTopic([FromBody] CreateTopicCommand command)
            => await Mediator.Send(command);

        //[HttpGet("{topicId}")]
        //public async Task<IActionResult> GetTopic(int topicId)
        //{
        //    Result<TopicMappingExtension.TopicDto> result = await Mediator.Send(new GetTopicsByForumIdQuery(topicId));
        //    return result.ToActionResult();
        //}
    }
}
