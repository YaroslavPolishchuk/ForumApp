
using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Application.Forums.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Forum.Application.Forums.Queries.GetBoard
{
    public class GetBoardHandler : IRequestHandler<GetBoardListQuery,IEnumerable<BoardListDto>>
    {
        private readonly IBoardOwnerService _service;

        public GetBoardHandler(IBoardOwnerService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<BoardListDto>> Handle(GetBoardListQuery request, CancellationToken cancellationToken)
        {
            var query = await _service.GetAvaliableEntities();
            //var result=await(query).ProjectTo<BoardListDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return null;
            //result;
        }
    }

    public record ForumDto(int Id, string Title, string? Description);
}
