using Dto.Models.ChatDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Models.UserDtos
{
    public class UserDto
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public IEnumerable<ChatDto> Chats { get; set; }
        public IEnumerable<MessageDto> Messages { get; set; }

    }
}
