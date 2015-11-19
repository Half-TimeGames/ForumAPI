using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class ForumContext : DbContext
    {
        public ForumContext() : base("ForumDb")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ForumContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<PrivateMessage> PrivateMessages { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
