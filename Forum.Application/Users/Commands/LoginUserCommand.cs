using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Users.Models;
using Forum.Infrastructure.Identity.Token;
using MediatR;

namespace Forum.Application.Users.Commands
{
    public record LoginUserCommand(LoginRequestModel LoginUserModel) : IRequest<Result>;
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
            var user = _context.Users.FirstOrDefault(u => u.UserName == request.LoginUserModel.Username);
            if (user == null)
                return Result.Failure(IdentityStatus.UserNotFound.ToString());

            bool isValid = BCrypt.Net.BCrypt.Verify(request.LoginUserModel.Password, user.PasswordHash);

            if (!isValid)
                return Result.Failure(IdentityStatus.InvalidPassword.ToString()); ;

            var token = _jwtUtil.GenerateToken(user.Id, user.UserName, user.Role);

            return Result.Success(new AuthResponse() { Token = token });
        }
    }
}