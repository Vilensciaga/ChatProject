using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Models.ChatDtos
{
    public class MessageDto
    {
        public int id { get; set; }
        public int ChatId { get; set; }
        public int MessageId { get; set; }
        public string message { get; set; }
    }
}
