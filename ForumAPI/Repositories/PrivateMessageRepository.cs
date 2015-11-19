using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void EditPrivateMessage(PrivateMessage privateMessage)
        {
            var p = _context.PrivateMessages.Single(x => x.Id == privateMessage.Id);
            DeletePrivateMessage(p);
            AddPrivateMessage(privateMessage);
            _context.SaveChanges();
        }

        public void DeletePrivateMessage(PrivateMessage privateMessage)
        {
            _context.PrivateMessages.Remove(privateMessage);
            _context.SaveChanges();
        }
    }
}
