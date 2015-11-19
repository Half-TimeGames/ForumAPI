using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class PrivateMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public User SenderUser { get; set; }
        [Required]
        public User ReceiverUser { get; set; }
        public string Text { get; set; }
    }
}
