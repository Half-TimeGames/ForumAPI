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
    class TopicRepository
    {
        private readonly ForumContext _context;

        public TopicRepository()
        {
            _context = new ForumContext();
        }

        public Topic GetTopic(int id)
        {
            return _context.Topics.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Topic> GetAllTopics()
        {
            return _context.Topics;
        }

        public void AddTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            _context.SaveChanges();
        }

        public bool EditTopic(Topic topic, int id)
        {
            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
                {
                    return false;
                }
                throw;
            }
            return true;
        }

        public void DeleteTopic(Topic topic)
        {
            _context.Topics.Remove(topic);
            _context.SaveChanges();
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Count(e => e.Id == id) > 0;
        }
    }
}
