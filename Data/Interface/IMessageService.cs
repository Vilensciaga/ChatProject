using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IMessageService
    {
        Task<Message> SendMessageAsync(int chatId, int senderId, string content);
        Task<List<Message>> GetMessagesForChatAsync(int chatId);
    }
}
