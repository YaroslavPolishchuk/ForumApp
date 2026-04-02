using Forum.Domain.Entities;

namespace Forum.Application.Common.Interfaces.Contexts
{
    public interface IAppVeloDbContext:IAppDbContext
    {
        IQueryable<Forum_> Forums => Resolve<Forum_>();
        IQueryable<Topic> Topics => Resolve<Topic>();
        IQueryable<Message> Messages => Resolve<Message>();
        IQueryable<User> Users => Resolve<User>();
    }
}
