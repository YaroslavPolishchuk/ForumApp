using Forum.Application.Common.Interfaces.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Forum.Infrastructure.Persistence
{
    public abstract class AppDbContext : DbContext, IAppDbContext
    {
        protected AppDbContext(DbContextOptions options) : base(options) { }

        public IQueryable<TEntity> Resolve<TEntity>() where TEntity : class => Set<TEntity>();

        public async Task Create<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            Attach(entity);
            await SaveChangesAsync(cancellationToken);
            Entry(entity).State = EntityState.Detached;
            //await Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async Task Save<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            await base.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveList<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken) where TEntity : class
        {
            await SaveChangesAsync(cancellationToken);
            foreach (var item in entities)
                Entry(item).State = EntityState.Detached;
        }

        public async Task Remove<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            var prop = typeof(TEntity).GetProperty("State");
            if (prop == default)
            {
                Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                prop.SetValue(entity, EntityState.Deleted);
                Entry(entity).State = EntityState.Modified;
            }

            await SaveChangesAsync(cancellationToken);

            Entry(entity).State = EntityState.Detached;
            Set<TEntity>().Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveList<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken) where TEntity : class
        {
            RemoveRange(entities);

            await SaveChangesAsync(cancellationToken);
            foreach (TEntity item in entities)
            {
                Entry(item).State = EntityState.Detached;
            }
            
        }

        public async Task Update<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;

            await SaveChangesAsync(cancellationToken);

            Entry(entity).State = EntityState.Detached;
        }

        public EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class => base.Attach(entity);

        public async Task<IDbContextTransaction> BeginTransaction() =>
            await Database.BeginTransactionAsync();

        public abstract IAppDbContext Copy();
    }
}
