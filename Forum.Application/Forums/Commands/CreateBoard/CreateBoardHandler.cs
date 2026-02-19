using Forum.Application.Common.Interfaces.Contexts;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Forums.Commands.CreateBoard
{
    public class CreateBoardHandler : IRequestHandler<CreateBoardCommand, int>
    {
        private readonly IAppVeloDbContext _context;
        public CreateBoardHandler(IAppVeloDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var forum = new Board
            {
                Title = request.Title,
                Description = request.Description
            };

            await _context.Create(forum,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return forum.Id;
        }
    }
}
