using Forum.Domain.Entities;

namespace Forum.Application.Common.Mapping.ForumUser
{
    public static class UserMappingExtensions
    {
        public static UserDto MapToDto(this User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            };
        }
        public static IEnumerable<UserDto> MapToDto(this IEnumerable<User> users)
        {
            return users.Select(user => user.MapToDto());
        }
    }
}
