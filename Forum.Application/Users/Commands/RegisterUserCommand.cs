using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Users.Models;
using MediatR;

namespace Forum.Application.Users.Commands
{
    public record RegisterUserCommand(
                    string Username,
                    string Email,  
                    string Password
    ) : IRequest<Result>;

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result>
    {
        private readonly IAppVeloDbContext _context;
        public RegisterUserHandler(IAppVeloDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
                return Result.Failure(PossibleResponse.UserAlreadyExists);

            if (_context.Users.Any(u => u.UserName == request.Username))
                return Result.Failure(PossibleResponse.NameAlreadyInUse);            

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

            var user = new Domain.Entities.User
            {
                UserName = request.Username,
                Email = request.Email,
                PasswordHash = hash,
                CreatedAt = DateTime.UtcNow,
                Role = "ForumUser"
            };
            await _context.Create(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(PossibleResponse.Success);
        }
    }
}
