using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
        [MaxLength(50000,ErrorMessage = "Post too long"), MinLength(2, ErrorMessage = "Post too short"), Required]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
