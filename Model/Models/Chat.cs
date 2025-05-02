using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public partial class Chat
    {

        public Chat()
        {
            Messages = new HashSet<Message>();
            //Users = new HashSet<User>();
            
        }
        [Key]
        public int ChatId { get; set; }

        public string ChatName { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; } = new HashSet<ChatUser>();
        //public virtual ICollection<User> Users { get; set; }

    }
}
