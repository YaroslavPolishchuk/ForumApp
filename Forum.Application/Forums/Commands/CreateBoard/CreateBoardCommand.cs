using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Forums.Commands.CreateBoard
{
    public record CreateBoardCommand(string Title, string Description) : IRequest<int>;
}
