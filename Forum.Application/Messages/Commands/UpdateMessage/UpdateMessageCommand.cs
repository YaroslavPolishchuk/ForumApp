using Forum.Application.Common.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Messages.Commands.UpdateMessage
{
    public record UpdateMessageCommand(int Id, string Content) : IRequest<Unit>;

    public class UpdateMessageHandler : IRequestHandler<UpdateMessageCommand, Unit>
    {
        private readonly IAppVeloDbContext _context;

        public UpdateMessageHandler(IAppVeloDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
            if (message != null)
            {
                message.Content = request.Content;
                message.UpdatedAt = DateTime.UtcNow;

                await _context.Update(message, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
