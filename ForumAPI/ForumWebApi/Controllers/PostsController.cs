using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using Repositories;

namespace ForumWebApi.Controllers
{
    public class PostsController : ApiController
    {
        private readonly ForumContext _context = new ForumContext();
        private readonly PostRepository _postRepository;

        public PostsController()
        {
            _postRepository = new PostRepository(_context);
        }

        // GET: api/Posts
        public IQueryable<Post> GetPosts()
        {
            return _postRepository.GetAllPosts().AsQueryable();
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = _postRepository.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }
            if (!_postRepository.EditPost(post, id))
                return NotFound();
            return Ok();
        }

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _postRepository.AddPost(post);

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = _postRepository.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }

            _postRepository.DeletePost(post);

            return Ok(post);
        }
    }
}
