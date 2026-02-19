using Forum.Application.Forums.Models;
using MediatR;

namespace Forum.Application.Forums.Queries.GetBoard
{
    public record GetBoardListQuery():IRequest<IEnumerable<BoardListDto>>;
}
