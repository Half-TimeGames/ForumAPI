using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Thread
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Topic Topic { get; set; }
        public string Subject { get; set; }
        public ICollection<Post> Posts { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
