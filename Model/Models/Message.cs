using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Message
    {
        public int id { get; set; }
        public int ChatId { get; set; }
        public int MessageId {  get; set; }
        public string message { get; set; }
    }
}
