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
    public class PostRepository
    {
        private readonly ForumContext _context;

        public PostRepository(ForumContext context)
        {
            _context = context;
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

        public bool EditPost(Post post, int id)
        {
            _context.Entry(post).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return false;
                }
                throw;
            }
            return true;
        }

        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Count(e => e.Id == id) > 0;
        }
    }
}
