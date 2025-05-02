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
    public class ChatUserService : IChatUserService
    {
        private readonly IAppDbContext context;

        public ChatUserService(IAppDbContext context)
        {
            this.context = context;
        }


        public async Task AddUserToChatAsync(int userId, int chatId)
        {
            var chat = await context.Chats.FirstOrDefaultAsync(u=> u.ChatId == chatId);
            if (chat == null)
            {
                throw new Exception("Chat not found");
            }

            await context.ChatUsers.AddAsync(new ChatUser { UserId = userId, ChatId = chatId });
            await context.SaveChangesAsync();
        }
        public async Task<List<User>> GetUsersInChatAsync(int chatId)
        {
            throw new NotImplementedException();
        }
        public async Task RemoveUserFromChatAsync(int userId, int chatId)
        {
            var chatUser = await context.ChatUsers.FirstOrDefaultAsync(c=> c.ChatId == chatId && c.UserId == userId);

            if (chatUser == null)
            {
                throw new Exception("Chat not found");
            }

            context.ChatUsers.Remove(chatUser);
            await context.SaveChangesAsync();
        }



        public async Task<List<Chat>> GetChatsForUserAsync(int userId)
        {
            return await context.ChatUsers.
                Where(u => u.UserId == userId)
                .Select(c => c.Chat)
                .Include(c => c.Messages)
                .ToListAsync();
        }
    }
   
}
