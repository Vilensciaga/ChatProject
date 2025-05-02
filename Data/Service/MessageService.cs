using Data.Interface;
using EntityFramework.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Service
{
    public class MessageService : IMessageService
    {
        private readonly IAppDbContext context;
        public MessageService(IAppDbContext context) 
        {
            this.context = context;
        }

        public async Task<List<Message>> GetMessagesForChatAsync(int chatId)
        {
            return await context.Messages.Where(c=> c.ChatId == chatId)
                .OrderBy(m=> m.Timestamp)
                .ToListAsync();
        }

        public async Task<Message> SendMessageAsync(int chatId, int senderId, string content)
        {
            Message message = new Message
            {
                ChatId = chatId,
                SenderId = senderId,
                message = content,
            };

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();
            return message;
        }
    }
}
