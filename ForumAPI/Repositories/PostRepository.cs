using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class PostRepository
    {
        private readonly ForumContext _context;

        public PostRepository()
        {
            _context = new ForumContext();
        }

        public Post GetPost(int id)
        {
            return _context.Posts.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void EditPost(Post post)
        {
            var p = _context.Posts.Single(x => x.Id == post.Id);
            DeletePost(p);
            AddPost(post);
            _context.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}
