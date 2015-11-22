using System.Data.Entity;
using Entities;

namespace Repositories
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("ForumDb")
        {
            Database.SetInitializer(new ForumInitializer<ForumContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
