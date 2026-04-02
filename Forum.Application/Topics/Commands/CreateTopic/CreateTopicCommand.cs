using Forum.Application.Common.Interfaces.Contexts;
using Forum.Domain.Entities;
using MediatR;
using System;

namespace Forum.Application.Topics.Commands.CreateTopic
{
    public record CreateTopicCommand(int id,int forumId, string title, string content, string authorName, DateTime createdAt,DateTime updatedAt) : IRequest<int>;

    public class CreateTopicHandler : IRequestHandler<CreateTopicCommand, int>
    {
        private readonly IAppVeloDbContext _context;

        public CreateTopicHandler(IAppVeloDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            var topic = new Topic
            {
                ForumId = request.forumId,
                AuthorName = request.authorName,
                Title = request.title,
                Content = request.content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Create(topic, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return topic.Id;
        }
    }
}

