using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Application.Common.Mapping;
using Forum.Application.Topics.Queries.GetTopics;
using Forum.Application.Users.Models;
using MediatR;
using System.Collections.Generic;

namespace Forum.Application.Topics.Queries.GetTopics
{
    public record GetTopicsByForumIdQuery(int ForumId) : IRequest<Result<IEnumerable<TopicMappingExtension.TopicDto>>>;
}
public class GetTopicsByForumIdHandler : IRequestHandler<GetTopicsByForumIdQuery, Result<IEnumerable<TopicMappingExtension.TopicDto>>>
{
    private readonly ITopicOwnerService _service;

    public GetTopicsByForumIdHandler(ITopicOwnerService service)
    {
        _service = service;
    }

    public async Task<Result<IEnumerable<TopicMappingExtension.TopicDto>>> Handle(GetTopicsByForumIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _service.GetAvaliableEntities();
        try
        {
            var entitiesDto = query.Where(d => d.ForumId == request.ForumId).ToArray();
            return Result.Success(entitiesDto.MapToDto());
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}