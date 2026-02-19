using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Application.Common.Services
{
    public class BoardOwnerService : IBoardOwnerService
    {
        IAppVeloDbContext _appVeloDbContext;
        public BoardOwnerService(IAppVeloDbContext appVeloDbContext) 
        {
        }

        public async Task<IQueryable<Board>> GetAvaliableEntities()
        {
            return _appVeloDbContext.Forums.AsNoTracking().AsQueryable();
        }

        public Task<bool> HasAcceessToDelete(int srcId)
        {
            throw new NotImplementedException();
        }
    }
}
