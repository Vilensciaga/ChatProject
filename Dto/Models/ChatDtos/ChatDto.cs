using Dto.Models.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Models.ChatDtos
{
    public class ChatDto
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }

        public IEnumerable<MessageDto> Messages { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}
