using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Text;
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

            IList<Topic> defaultTopics = new List<Topic>();

            defaultTopics.Add(new Topic() { Name = "Topic1" });
            defaultTopics.Add(new Topic() { Name = "Topic2" });
            defaultTopics.Add(new Topic() { Name = "Topic3" });

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

            defaultThreads.Add(new Thread() {DateCreated = DateTime.Now, Posts = threadPosts1, Topic = defaultTopics[0], Subject="Lorem Ipsum Dolor Sit Amet!"});
            defaultThreads.Add(new Thread() {DateCreated = DateTime.Now, Posts = threadPosts2, Topic = defaultTopics[1], Subject="Aliquam erat volutpat..."});
            defaultThreads.Add(new Thread() {DateCreated = DateTime.Now, Posts = threadPosts3, Topic = defaultTopics[2], Subject="Lol! Faggits! This is so gay!"});

            foreach (var defaultUser in defaultUsers)
            {
                context.Users.Add(defaultUser);
            }

            foreach (var defaultPost in defaultPosts)
            {
                context.Posts.Add(defaultPost);
            }

            foreach (var defaultTopic in defaultTopics)
            {
                context.Topics.Add(defaultTopic);
            }

            foreach (var defaulThread in defaultThreads)
            {
                context.Threads.Add(defaulThread);
            }

            base.Seed(context);
        }

        private static string LoremIpsum(int length)
        {
            var stringBuilder = new StringBuilder();
            var buffer = new char[length];
            using (var streamReader = new StreamReader("TextFiles/Lorem50k.txt"))
            {
                streamReader.Read(buffer, 0, length);
                return stringBuilder.Append(buffer, 0, length).ToString();
            }
        }
    }
}
