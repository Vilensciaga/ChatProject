
using Dto.Models.ChatDtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IChatService
    {
        Task<Message> GetMessageAsync(int messageId)    ;
        Task<MessageDto> CreateMessageAsync(MessageDto message) ;
        Task<IEnumerable<Message>> GetMessagesAsync(int chatId) ;
        Task<CreateChatDto> CreateChatAsync(CreateChatDto chatDto) ;
        Task DeleteChatAsync(int chatId) ;
        Task GetChatAsync(int chatId) ;

    }
}
