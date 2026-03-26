
using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Application.Common.Mapping;
using Forum.Application.Users.Models;
using Forum.Domain.Entities;
using MediatR;
using System.Diagnostics;
using static Forum.Application.Common.Mapping.ForumMappingExtension;

namespace Forum.Application.Forums.Queries.GetBoard
{
    public record GetForumsQuery() : IRequest<Result<IEnumerable<ForumDto>>>;
    public class GetForumsHandler : IRequestHandler<GetForumsQuery, Result<IEnumerable<ForumDto>>>
    {
        private readonly IForumOwnerService _service;

        public GetForumsHandler(IForumOwnerService service)
        {
            _service = service;
        }

        public async Task<Result<IEnumerable<ForumDto>>> Handle(GetForumsQuery request, CancellationToken cancellationToken)
        {
            var query = await _service.GetAvaliableEntities();
            try
            {
                var entitesDto = query.ToArray();
                return Result.Success(entitesDto.MapToDto());
            }
            catch(Exception ex)
            {                
                throw;
            }            
        }
    }

    
}
