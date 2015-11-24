using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Thread
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Topic Topic { get; set; }
        [Required]
        public string Subject { get; set; }
        public virtual ICollection<Post> Posts { get; set; } 
        public DateTime DateCreated { get; set; }
    }
}
