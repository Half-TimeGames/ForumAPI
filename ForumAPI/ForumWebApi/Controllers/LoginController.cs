using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using BusinessLayer;
using Repositories;

namespace ForumWebApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ForumContext _context = new ForumContext();
        private readonly LoginHandler _loginHandler;

        public LoginController()
        {
            _loginHandler = new LoginHandler(_context);
        }
        // GET api/login
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/login/emailPassword
        [ActionName("GetHash")]
        public string Get(string emailPassword)
        {
            string[] values = Regex.Split(emailPassword, "__");
            var user = _loginHandler.Login(values[0], values[1]);
            var hash = user.PasswordHash;
            return hash;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}