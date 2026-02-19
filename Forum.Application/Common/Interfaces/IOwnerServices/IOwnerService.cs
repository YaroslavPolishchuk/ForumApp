using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Common.Interfaces.IOwnerServices
{
    public interface IOwnerService<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAvaliableEntities();
        Task<bool> HasAcceessToDelete(int srcId);
    }
}
