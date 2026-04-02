using Forum.Application.Common.Interfaces.Contexts;
using Forum.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Forum.Application.Messages.Commands.CreateMessage
{
    public record CreateMessageCommand(int Id, int TopicId, Guid AuthorId, string Content, DateTime CreatedAt, DateTime? UpdatedAt) : IRequest<int>;

    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IAppVeloDbContext _context;

        public CreateMessageHandler(IAppVeloDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                ThreadId = request.TopicId, // ThreadId maps to TopicId
                AuthorId = request.AuthorId,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Create(message, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return message.Id;
        }
    }
}
