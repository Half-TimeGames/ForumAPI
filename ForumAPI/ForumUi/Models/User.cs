using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ForumUi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public object PasswordHash { get; set; }
        public string DateCreated { get; set; }
        public object Avatar { get; set; }
    }
}