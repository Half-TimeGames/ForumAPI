using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Entities;

namespace Repositories
{
    public class PrivateMessageRepository
    {
        private readonly ForumContext _context;

        public PrivateMessageRepository()
        {
            _context = new ForumContext();
        }

        public PrivateMessage GetPrivateMessage(int id)
        {
            return _context.PrivateMessages.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<PrivateMessage> GetAllPrivateMessages()
        {
            return _context.PrivateMessages;
        }

        public void AddPrivateMessage(PrivateMessage privateMessage)
        {
            _context.PrivateMessages.Add(privateMessage);
            _context.SaveChanges();
        }

        public bool EditPrivateMessage(PrivateMessage privateMessage, int id)
        {
            _context.Entry(privateMessage).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrivateMessageExists(id))
                {
                    return false;
                }
                throw;
            }
            return true;
        }

        public void DeletePrivateMessage(PrivateMessage privateMessage)
        {
            _context.PrivateMessages.Remove(privateMessage);
            _context.SaveChanges();
        }

        private bool PrivateMessageExists(int id)
        {
            return _context.PrivateMessages.Count(e => e.Id == id) > 0;
        }
    }
}
