using Forum.Domain.Entities;

namespace Forum.Application.Common.Interfaces.Contexts
{
    public interface IAppVeloDbContext:IAppDbContext
    {
        IQueryable<Board> Forums => Resolve<Board>();
        IQueryable<Discussion> Discussions => Resolve<Discussion>();
        IQueryable<Message> Messages => Resolve<Message>();
        IQueryable<User> Users => Resolve<User>();
    }
}
