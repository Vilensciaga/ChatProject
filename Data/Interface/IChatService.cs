
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
        Task<Chat> CreateChatAsync(IEnumerable<int> userIds, string chatName = null);
        Task<Chat?> GetChatByIdAsync(int chatId);
        

    }
}
