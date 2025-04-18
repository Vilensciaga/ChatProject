using Data.Interface;
using Dto.Models.ChatDtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class ChatService : IChatService
    {
        public Task<CreateChatDto> CreateChatAsync(CreateChatDto chatDto)
        {
            throw new NotImplementedException();
        }

        public Task<MessageDto> CreateMessageAsync(MessageDto message)
        {
            throw new NotImplementedException();
        }

        public Task DeleteChatAsync(int chatId)
        {
            throw new NotImplementedException();
        }

        public Task GetChatAsync(int chatId)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetMessageAsync(int messageId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetMessagesAsync(int chatId)
        {
            throw new NotImplementedException();
        }
    }
}
