using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    //TODO FindUserByHash
    public class UserRepository
    {
        private readonly ForumContext _context;

        public UserRepository(ForumContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void EditUser(User user)
        {
            var u = _context.Users.Single(x => x.Id == user.Id);
            DeleteUser(u);
            AddUser(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
