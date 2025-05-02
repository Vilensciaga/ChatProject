using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Interface
{
    public interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }  

        public DbSet<Administrator> Administrators { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
