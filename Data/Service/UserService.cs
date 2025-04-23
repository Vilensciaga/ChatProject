using Data.Interface;
using Dto.Models.UserDtos;
using EntityFramework.Adapter;
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
    public class UserService : IUserService
    {
        private readonly IAppDbContext userDb;
        private readonly AppDbContext context; 

        public UserService(IAppDbContext userDb, AppDbContext context)
        {
            this.userDb = userDb;
            this.context = context;
        }

        public async Task<User> CreateUserAsync(CreateUserDto userDto)
        {
            User newuser = new()
            {
                FirstName = userDto.firstName,
                LastName = userDto.lastName,
                email = userDto.email,
                password = userDto.password
            };


            await userDb.Users.AddAsync(newuser);
            await userDb.SaveChangesAsync();
            return newuser;
        }

        public async Task<User> CreateUserWithTriggerAsync(CreateUserDto userDto)
        {
            User newuser = new()
            {
                FirstName = userDto.firstName,
                LastName = userDto.lastName,
                email = userDto.email,
                password = userDto.password
            };


            await context.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO Users (firstName, lastName, email, password) VALUES ({newuser.FirstName}, {newuser.LastName}, {newuser.email}, {newuser.password})");
            return newuser;
        }
        public async Task DeleteUserAsync(int id)
        {
            var existinguser = await GetUserAsync(id);
            userDb.Users.Remove(existinguser);
            await userDb.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await userDb.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await userDb.Users.FirstOrDefaultAsync(p => p.email == email);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await userDb.Users.ToListAsync();
        }

        public async Task<UpdateUserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
        {
            var existinguser = await GetUserAsync(id);

            if (existinguser != null)
            {

                existinguser.LastName = userDto.lastName;
                existinguser.FirstName = userDto.firstName;
                existinguser.email = userDto.email;

                await userDb.SaveChangesAsync();

            }
            return userDto;
        }
    }
}
