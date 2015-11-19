using Entities;
using System;
using System.Collections.Generic;
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

        public void EditTopic(Topic topic)
        {
            var p = _context.Topics.Single(x => x.Id == topic.Id);
            DeleteTopic(p);
            AddTopic(topic);
            _context.SaveChanges();
        }

        public void DeleteTopic(Topic topic)
        {
            _context.Topics.Remove(topic);
            _context.SaveChanges();
        }
    }
}
