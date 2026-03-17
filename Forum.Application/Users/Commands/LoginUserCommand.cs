using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Common.Mapping.ForumUser;
using Forum.Application.Users.Models;
using Forum.Domain.Entities;
using Forum.Infrastructure.Identity.Token;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Forum.Application.Users.Commands
{
    public record LoginUserCommand(string Username,
                    string Password) : IRequest<Result>;
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result>
    {
        private readonly IAppVeloDbContext _context;
        private readonly IJwtUtils _jwtUtil;

        public LoginUserHandler(IAppVeloDbContext context, IJwtUtils jwtUtil)
        {
            _context = context;
            _jwtUtil = jwtUtil;
        }
        public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == request.Username);
            if (user == null)
                return Result.Failure(PossibleResponse.UserNotFound);

            bool isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isValid)
                return Result.Failure(PossibleResponse.InvalidPassword); 

            var token = _jwtUtil.GenerateToken(user.Id, user.UserName, user.Role);
            var userDto = user.MapToDto();
            return Result.Success(new AuthResponse()
            {
                AccessToken = token,
                RefreshToken = token,
                User = userDto
            });
        }
    }
}