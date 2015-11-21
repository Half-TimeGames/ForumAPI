using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    class ThreadRepository
    {
        private readonly ForumContext _context;

        public ThreadRepository()
        {
            _context = new ForumContext();
        }

        public Thread GetThread(int id)
        {
            return _context.Threads.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Thread> GetAllThreads()
        {
            return _context.Threads;
        }

        public void AddThread(Thread thread)
        {
            _context.Threads.Add(thread);
            _context.SaveChanges();
        }

        //public IEnumerable<Thread> GetThreadsByTopic(Topic topic)
        //{
        //    _context.Threads.
        //} 

        public bool EditThread(Thread thread, int id)
        {
            _context.Entry(thread).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadExists(id))
                {
                    return false;
                }
                throw;
            }
            return true;
        }

        public void DeleteThread(Thread thread)
        {
            _context.Threads.Remove(thread);
            _context.SaveChanges();
        }

        private bool ThreadExists(int id)
        {
            return _context.Threads.Count(e => e.Id == id) > 0;
        }
    }
}
