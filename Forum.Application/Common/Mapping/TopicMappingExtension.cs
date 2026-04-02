using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Application.Common.Mapping
{
    public static class TopicMappingExtension
    {
        public record TopicDto(int Id, int ForumId, string AuthorName, string Title, string Content, DateTime CreatedAt, DateTime? UpdatedAt);

        public static TopicDto MapToDto(this Topic topic)
        {
            if (topic == null) return null;

            return new TopicDto
            (
                topic.Id,
                topic.ForumId,
                topic.AuthorName,
                topic.Title,
                topic.Content,
                topic.CreatedAt,
                topic.UpdatedAt
            );
        }

        public static IEnumerable<TopicDto> MapToDto(this IEnumerable<Topic> entities)
        {
            return entities.Select(d => d.MapToDto());
        }
    }
}
