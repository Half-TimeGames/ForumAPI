using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class ForumInitializer<TContext> : DropCreateDatabaseAlways<ForumContext>
    {
        //TODO Write seed method for database
        //TODO Hash and salt password on users
        protected override void Seed(ForumContext context)
        {
            IList<User> defaultUsers = new List<User>();

            defaultUsers.Add(new User() { Username = "User1", Email = "User1@contoso.com", DateCreateed = DateTime.Now });
            defaultUsers.Add(new User() { Username = "User2", Email = "User2@contoso.com", DateCreateed = DateTime.Now });
            defaultUsers.Add(new User() { Username = "User3", Email = "User3@contoso.com", DateCreateed = DateTime.Now });
            defaultUsers.Add(new User() { Username = "User4", Email = "User4@contoso.com", DateCreateed = DateTime.Now });

            foreach (var defaultUser in defaultUsers)
            {
                context.Users.Add(defaultUser);
            }

            IList<Topic> defaulTopics = new List<Topic>();

            defaulTopics.Add(new Topic() { Name = "Topic1" });
            defaulTopics.Add(new Topic() { Name = "Topic2" });
            defaulTopics.Add(new Topic() { Name = "Topic3" });

            foreach (var defaulTopic in defaulTopics)
            {
                context.Topics.Add(defaulTopic);
            }

            IList<Post> defaultPosts = new List<Post>();

            defaultPosts.Add(new Post() { User = defaultUsers[0], DateCreated = DateTime.Now, Text = LoremIpsum(50000) });
            defaultPosts.Add(new Post() { User = defaultUsers[2], DateCreated = DateTime.Now, Text = LoremIpsum(100) });
            defaultPosts.Add(new Post() { User = defaultUsers[0], DateCreated = DateTime.Now, Text = LoremIpsum(3000) });
            defaultPosts.Add(new Post() { User = defaultUsers[1], DateCreated = DateTime.Now, Text = LoremIpsum(400) });
            defaultPosts.Add(new Post() { User = defaultUsers[3], DateCreated = DateTime.Now, Text = LoremIpsum(50) });
            defaultPosts.Add(new Post() { User = defaultUsers[2], DateCreated = DateTime.Now, Text = LoremIpsum(10000) });
            defaultPosts.Add(new Post() { User = defaultUsers[0], DateCreated = DateTime.Now, Text = LoremIpsum(755) });
            defaultPosts.Add(new Post() { User = defaultUsers[1], DateCreated = DateTime.Now, Text = LoremIpsum(5000) });
            defaultPosts.Add(new Post() { User = defaultUsers[3], DateCreated = DateTime.Now, Text = LoremIpsum(666) });

            foreach (var defaultPost in defaultPosts)
            {
                context.Posts.Add(defaultPost);
            }

            ICollection<Post> threadPosts1 = new List<Post>()
            {
                defaultPosts[0],
                defaultPosts[1],
                defaultPosts[2]
            };
            ICollection<Post> threadPosts2 = new List<Post>()
            {
                defaultPosts[3],
                defaultPosts[4],
                defaultPosts[5]
            };
            ICollection<Post> threadPosts3 = new List<Post>()
            {
                defaultPosts[6],
                defaultPosts[7],
                defaultPosts[8]
            };

            IList<Thread> defaultThreads = new List<Thread>();

            defaultThreads.Add(new Thread() {DateCreated = DateTime.Now, Posts = threadPosts1, Topic = defaulTopics[0], Subject="Lorem Ipsum Dolor Sit Amet!"});
            defaultThreads.Add(new Thread() {DateCreated = DateTime.Now, Posts = threadPosts2, Topic = defaulTopics[1], Subject="Aliquam erat volutpat..."});
            defaultThreads.Add(new Thread() {DateCreated = DateTime.Now, Posts = threadPosts3, Topic = defaulTopics[2], Subject="Lol! Faggits! This is so gay!"});

            foreach (var defaulThread in defaultThreads)
            {
                context.Threads.Add(defaulThread);
            }

            base.Seed(context);
        }

        private static string LoremIpsum(int length)
        {
            var buffer = new char[length];
            using (var streamReader = new StreamReader("C:\\Users\\andre\\Source\\Repos\\ForumAPI\\ForumAPI\\Repositories\\TextFiles\\Lorem50k.txt"))
            {
                return streamReader.Read(buffer, 0, length).ToString();
            }
        }
    }
}
