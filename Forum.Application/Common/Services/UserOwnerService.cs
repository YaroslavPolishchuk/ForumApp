using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Common.Interfaces.IOwnerServices;

using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Application.Common.Services
{
    public class UserOwnerService : IUserOwnerService
    {
        IAppVeloDbContext _appVeloDbContext;
        public UserOwnerService(IAppVeloDbContext appVeloDbContext)
        {
            _appVeloDbContext = appVeloDbContext;
        }

        public async Task<IQueryable<User>> GetAvaliableEntities()
        {
            return _appVeloDbContext.Users.AsNoTracking().AsQueryable();
        }

        public Task<bool> HasAcceessToDelete(int srcId)
        {
            throw new NotImplementedException();
        }
    }
}
