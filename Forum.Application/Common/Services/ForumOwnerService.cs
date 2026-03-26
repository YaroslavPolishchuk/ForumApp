using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Application.Common.Services
{
    public class ForumOwnerService : IForumOwnerService
    {
        IAppVeloDbContext _appVeloDbContext;
        public ForumOwnerService(IAppVeloDbContext appVeloDbContext) 
        {
            _appVeloDbContext = appVeloDbContext;
        }        
        public async Task<IQueryable<Forum_>> GetAvaliableEntities()
        {
            return _appVeloDbContext.Forums.AsNoTracking().AsQueryable();
        }

        public Task<bool> HasAcceessToDelete(int srcId)
        {
            throw new NotImplementedException();
        }
    }
}
