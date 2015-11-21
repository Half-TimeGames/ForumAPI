using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class LoginRepository
    {
        private readonly ForumContext _context;

        public User Login(string email, string password)
        {

            User currentUser = _context.Users.SingleOrDefault(x => x.Email == email);

                if (currentUser == null)
                    return null;
                else if (getHash(password, currentUser.PasswordSalt) == currentUser.PasswordHash)
                    return currentUser;
                else
                    return null;
        }

        public string getHash(string password, string salt)
        {
            SHA256Managed hashe = new SHA256Managed();

            byte[] hash = hashe.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
            string hex = BitConverter.ToString(hash).Replace("-", "");

            return hex;
        }

        public string RandomString(int length)
        {
            Random rand = new Random();
            string String = "";
            for (int i = 0; i < length; i++)
            {

                String += (char)rand.Next(65, 91);
            }
            return String;
        }
    }
}
