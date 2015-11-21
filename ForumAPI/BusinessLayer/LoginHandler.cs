using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Repositories;

namespace BusinessLayer
{
    public class LoginHandler
    {
        private readonly UserRepository _userRepository;

        public LoginHandler(ForumContext forumContext)
        {
            _userRepository = new UserRepository(forumContext);
        }

        public User Login(string email, string password)
        {

            User currentUser = _userRepository.FindUserByEmail(email);

            if (currentUser == null)
                return null;
            if (GetHash(password, currentUser.PasswordSalt) == currentUser.PasswordHash)
                return currentUser;

            return null;
        }

        public string GetHash(string password, string salt)
        {
            SHA256Managed hashe = new SHA256Managed();

            byte[] hash = hashe.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
            string hex = BitConverter.ToString(hash).Replace("-", "");

            return hex;
        }

        public string RandomString(int length)
        {
            Random rand = new Random();
            string randomString = "";
            for (int i = 0; i < length; i++)
            {

                randomString += (char)rand.Next(65, 91);
            }
            return randomString;
        }
    }
}
