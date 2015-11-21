using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    //TODO FindByHash
    public class UserRepository
    {
        private readonly ForumContext _context;

        public UserRepository(ForumContext context)
        {
            _context = context;
        }

        public  User GetUser(int id)
        {
            return  _context.Users.SingleOrDefault(x => x.Id == id);
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

        public bool EditUser(User user, int id)
        {
            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Count(e => e.Id == id) > 0;
        }
    }
}
