using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IChatUserService
    {
        Task AddUserToChatAsync(int userId, int chatId);
        Task RemoveUserFromChatAsync(int userId, int chatId);
        Task<List<User>> GetUsersInChatAsync(int chatId);
        Task<List<Chat>> GetChatsForUserAsync(int userId);
    }
}
