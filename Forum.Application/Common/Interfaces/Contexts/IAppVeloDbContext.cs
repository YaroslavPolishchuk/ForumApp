using Forum.Domain.Entities;

namespace Forum.Application.Common.Interfaces.Contexts
{
    public interface IAppVeloDbContext:IAppDbContext
    {
        IQueryable<Forum_> Forums => Resolve<Forum_>();
        IQueryable<Discussion> Discussions => Resolve<Discussion>();
        IQueryable<Message> Messages => Resolve<Message>();
        IQueryable<User> Users => Resolve<User>();
    }
}
