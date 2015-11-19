using Entities;
using System;
using System.Collections.Generic;
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

        public void EditThread(Thread thread)
        {
            var p = _context.Threads.Single(x => x.Id == thread.Id);
            DeleteThread(p);
            AddThread(thread);
            _context.SaveChanges();
        }

        public void DeleteThread(Thread thread)
        {
            _context.Threads.Remove(thread);
            _context.SaveChanges();
        }
    }
}
