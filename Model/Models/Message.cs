using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Message
    {
        //public int id { get; set; }
        public int ChatId { get; set; }

        [Key]
        public int MessageId {  get; set; }
        public string message { get; set; }

        public int SenderId { get; set; }
        public DateTime Timestamp { get; set; }

        public bool IsRead { get; set; }

        public User Sender { get; set; }
        public virtual Chat Chat { get; set; }
        public DateTime date { get; set; }
    }
}
