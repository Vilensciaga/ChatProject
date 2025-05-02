
using System.ComponentModel.DataAnnotations;

namespace Model.Models

{
    public class User
    {
        
        public int Id {  get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(40)]
        public string password { get; set; }

        //public Administrator Administrator { get; set; }
        //public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<ChatUser> UserChats { get; set; } = new HashSet<ChatUser>();

        public virtual ICollection<Message> Messages { get; set; }

    }
}
