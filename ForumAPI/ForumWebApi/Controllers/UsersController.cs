using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLayer;
using Entities;
using Repositories;

namespace ForumWebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly ForumContext _context = new ForumContext();
        private readonly UserRepository _userRepository;
        private readonly LoginHandler _loginHandler;
        

        public UsersController()
        {
            _userRepository = new UserRepository(_context);
            _loginHandler = new LoginHandler(_context);
        }

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return _userRepository.GetAllUsers().AsQueryable();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }
            if (!_userRepository.EditUser(user, id))
                return NotFound();
            return Ok();
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            user.DateCreated = DateTime.Now;
            user.PasswordSalt = _loginHandler.RandomString(16);
            user.PasswordHash = _loginHandler.GetHash(password, user.PasswordSalt);

            _userRepository.AddUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(user);

            return Ok(user);
        }
    }
}
