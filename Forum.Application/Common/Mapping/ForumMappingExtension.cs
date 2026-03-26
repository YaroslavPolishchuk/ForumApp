using Forum.Application.Common.Mapping.ForumUser;
using Forum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.Mapping
{
    public static class ForumMappingExtension
    {
        public record ForumDto(int Id, string Title, string? Description);

        public static ForumDto MapToDto(this Forum_ forum)
        {
            if (forum == null) return null;

            return new ForumDto
            (
                forum.Id,
                forum.Title,
                forum.Description                
            );
        }

        public static IEnumerable<ForumDto> MapToDto(this IEnumerable<Forum_> entities)
        {
            return entities.Select(f => f.MapToDto());
        }
    }
}
