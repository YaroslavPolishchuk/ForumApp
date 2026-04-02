using Forum.Application.Common.Interfaces.Contexts;
using Forum.Application.Common.Interfaces.IOwnerServices;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Application.Common.Services
{    
    public class TopicOwnerService : ITopicOwnerService
    {
        IAppVeloDbContext _appVeloDbContext;
        public TopicOwnerService(IAppVeloDbContext appVeloDbContext)
        {
            _appVeloDbContext = appVeloDbContext;
        }
        public async Task<IQueryable<Topic>> GetAvaliableEntities()
        {
            return _appVeloDbContext.Topics.AsNoTracking().AsQueryable();
        }

        public Task<bool> HasAcceessToDelete(int srcId)
        {
            throw new NotImplementedException();
        }
    }
}
