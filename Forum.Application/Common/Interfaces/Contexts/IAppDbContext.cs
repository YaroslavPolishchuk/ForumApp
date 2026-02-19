using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.CodeAnalysis;

namespace Forum.Application.Common.Interfaces.Contexts
{
    public interface IAppDbContext
    {
        Task Update<TEntity>(TEntity data, CancellationToken cancellationToken) where TEntity : class;        

        Task Remove<TEntity>(TEntity data, CancellationToken cancellationToken) where TEntity : class;

        Task<IDbContextTransaction> BeginTransaction();

        Task SaveList<TEntity>(IEnumerable<TEntity> data, CancellationToken cancellationToken = default) where TEntity : class;
        Task Save<TEntity>(TEntity data, CancellationToken cancellationToken = default) where TEntity : class;

        IQueryable<TEntity> Resolve<TEntity>() where TEntity : class;

        IAppDbContext Copy();
        Task Create<TEntity>(TEntity data, CancellationToken cancellationToken) where TEntity : class;


        EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity) where TEntity : class;
        Task RemoveList<TEntity>(IEnumerable<TEntity> data, CancellationToken cancellationToken) where TEntity : class;        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
