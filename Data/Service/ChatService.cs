using Data.Interface;
using Dto.Models.ChatDtos;
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
    public class ChatService : IChatService
    {
        private readonly IAppDbContext context;
        public ChatService(IAppDbContext context)
        {
            this.context = context;
        }

        public async Task<Chat> CreateChatAsync(IEnumerable<int> userIds, string chatName = null)
        {
            Chat chat = new Chat
            {
                ChatName = chatName,
                CreatedAt = DateTime.UtcNow,
                
            };

            foreach (var userId in userIds)
            {
                chat.ChatUsers.Add(new ChatUser { UserId = userId });
            }

            await context.Chats.AddAsync(chat);
            await context.SaveChangesAsync();
            return chat;
        }

        public async Task<Chat?> GetChatByIdAsync(int chatId)
        {
            return await context.Chats
                .Include(c=> c.Messages)
                .Include(c=> c.ChatUsers)
                .ThenInclude(uc=>uc.User)
                .FirstOrDefaultAsync(c => c.ChatId == chatId);
        }

       
    }
}
