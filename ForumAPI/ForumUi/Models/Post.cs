using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumUi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public string DateCreated { get; set; }
    }
}