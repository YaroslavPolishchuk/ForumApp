using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Users.Models;
using MediatR;

namespace Forum.Application.Users.Commands
{
    public record RegisterUserCommand(
                    string Username,
                    string Email,
                    string Password
    ) : IRequest<IdentityStatus>;

    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, IdentityStatus>
    {
        private readonly IAppVeloDbContext _context;
        public RegisterUserHandler(IAppVeloDbContext context)
        {
            _context = context;
        }
        public async Task<IdentityStatus> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
                return IdentityStatus.UserAlreadyExists;

            if (_context.Users.Any(u => u.UserName == request.Username))
                return IdentityStatus.NameAlreadyInUse;            

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);

            var user = new Domain.Entities.User
            {
                UserName = request.Username,
                Email = request.Email,
                PasswordHash = hash,
                CreatedAt = DateTime.UtcNow,
                Role = "Admin"
            };
            await _context.Create(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return IdentityStatus.Success;
        }
    }
}
