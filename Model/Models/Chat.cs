using System;
using System.Collections.Generic;
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
            Users = new HashSet<User>();
            
        }
        public int ChatId { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
