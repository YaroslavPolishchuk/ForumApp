using Forum.Application.Common.Interfaces.Contexts;
using Forum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forum.Infrastructure.Persistence
{
    public class VeloContext : AppDbContext, IAppVeloDbContext
    {
        public VeloContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Forum_> Forums { get; set; }
        public virtual DbSet<Discussion> Discussions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum_>(e =>
            {
                e.ToTable("forums");
                e.Property(p => p.Id).HasColumnName("id");
                e.Property(p => p.Description).HasColumnName("description");
                e.Property(p => p.Title).HasColumnName("title");
                e.Property(p => p.Answers).HasColumnName("answers");
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.Property(p => p.Id).HasColumnName("id");
                e.Property(p => p.UserName).HasColumnName("username");
                e.Property(p => p.Email).HasColumnName("email");
                e.Property(p => p.PasswordHash).HasColumnName("passwordhash");
                e.Property(p => p.CreatedAt).HasColumnName("createdat");
                e.Property(p => p.Role).HasColumnName("role");
            });

        }
        public override IAppDbContext Copy()
        {
            throw new NotImplementedException();
        }
    }
}
