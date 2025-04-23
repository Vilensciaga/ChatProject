using Dto.Models.UserDtos;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> CreateUserAsync(CreateUserDto userDto);
        Task<User> CreateUserWithTriggerAsync(CreateUserDto userDto);
        Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto userDto);
        Task DeleteUserAsync(int id);
    }
}
