using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumUi.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public object Topic { get; set; }
        public string Subject { get; set; }
        public object Posts { get; set; }
        public string DateCreated { get; set; }
    }
}