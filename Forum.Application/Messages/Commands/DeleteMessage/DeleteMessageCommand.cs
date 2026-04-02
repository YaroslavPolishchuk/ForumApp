using Forum.Application.Common.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Messages.Commands.DeleteMessage
{
    public record DeleteMessageCommand(int Id) : IRequest<Unit>;

    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand, Unit>
    {
        private readonly IAppVeloDbContext _context;

        public DeleteMessageHandler(IAppVeloDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (message != null)
            {
                await _context.Remove(message, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
