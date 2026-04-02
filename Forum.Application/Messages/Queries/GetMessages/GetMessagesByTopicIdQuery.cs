using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Application.Common.Mapping;
using Forum.Application.Users.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Messages.Queries.GetMessages
{
    public record GetMessagesByTopicIdQuery(int TopicId) : IRequest<Result<IEnumerable<MessageMappingExtension.MessageDto>>>;

    public class GetMessagesByTopicIdHandler : IRequestHandler<GetMessagesByTopicIdQuery, Result<IEnumerable<MessageMappingExtension.MessageDto>>>
    {
        private readonly IMessageOwnerService _service;

        public GetMessagesByTopicIdHandler(IMessageOwnerService service)
        {
            _service = service;
        }

        public async Task<Result<IEnumerable<MessageMappingExtension.MessageDto>>> Handle(GetMessagesByTopicIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _service.GetAvaliableEntities();
            try
            {
                var entitiesDto = query.Where(d => d.ThreadId == request.TopicId).ToArray();
                return Result.Success(entitiesDto.MapToDto());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
