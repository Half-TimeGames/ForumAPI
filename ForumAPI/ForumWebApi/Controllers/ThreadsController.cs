using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Entities;
using Repositories;

namespace ForumWebApi.Controllers
{
    public class ThreadsController : ApiController
    {
        private readonly ForumContext _context = new ForumContext();
        private readonly ThreadRepository _threadRepository;
        private readonly PostRepository _postRepository;

        public ThreadsController()
        {
            _threadRepository = new ThreadRepository(_context);
            _postRepository = new PostRepository(_context);
        }

        // GET: api/Threads
        public IQueryable<Thread> GetThreads()
        {
            return _threadRepository.GetAllThreads().AsQueryable();
        }

        // GET: api/Threads/5
        [ResponseType(typeof(Thread))]
        public IHttpActionResult GetThread(int id)
        {
            Thread thread = _threadRepository.GetThread(id);
            if (thread == null)
            {
                return NotFound();
            }

            return Ok(thread);
        }

        // PUT: api/Threads/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutThread(int id, Thread thread)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != thread.Id)
            {
                return BadRequest();
            }
            if (!_threadRepository.EditThread(thread, id))
                return NotFound();
            return Ok();
        }

        // POST: api/Threads
        [ResponseType(typeof(Thread))]
        public IHttpActionResult PostThread(Thread thread, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _threadRepository.AddThread(thread);

            return CreatedAtRoute("DefaultApi", new { id = thread.Id }, thread);
        }

        // DELETE: api/Threads/5
        [ResponseType(typeof(Thread))]
        public IHttpActionResult DeleteThread(int id)
        {
            Thread thread = _threadRepository.GetThread(id);
            if (thread == null)
            {
                return NotFound();
            }

            _threadRepository.DeleteThread(thread);

            return Ok(thread);
        }
    }
}
