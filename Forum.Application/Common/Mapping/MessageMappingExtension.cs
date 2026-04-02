using Forum.Domain.Entities;

namespace Forum.Application.Common.Mapping
{
    public static class MessageMappingExtension
    {
        public class MessageDto
        {
            public int Id { get; set; }
            public int TopicId { get; set; }
            public Guid AuthorId { get; set; }
            public string Content { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }

        public static IEnumerable<MessageDto> MapToDto(this IEnumerable<Message> entities)
        {
            return entities.Select(e => new MessageDto
            {
                Id = e.Id,
                TopicId = e.ThreadId,
                AuthorId = e.AuthorId,
                Content = e.Content,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            });
        }
    }
}
