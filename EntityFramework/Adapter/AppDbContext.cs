using EntityFramework.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EntityFramework.Adapter
{
    public class AppDbContext : DbContext, IAppDbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public DbSet<ChatUser> ChatUsers { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Chats)
            //    .WithMany(u => u.Users);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.SenderId);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Chat)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatId);

            modelBuilder.Entity<ChatUser>()
                .HasKey(uc => new { uc.UserId, uc.ChatId });

            modelBuilder.Entity<ChatUser>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserChats)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<ChatUser>()
                .HasOne(uc => uc.Chat)
                .WithMany(c => c.ChatUsers)
                .HasForeignKey(uc => uc.ChatId);

            modelBuilder.Entity<ChatUser>()
                .HasOne(uc => uc.Chat)
                .WithMany(c => c.ChatUsers)
                .HasForeignKey(uc => uc.ChatId);




            //modelBuilder.Entity<Message>()
            //    .HasOne(m => m.Chat)
            //    .WithMany(u => u.Messages)
            //    .HasForeignKey(m => m.ChatId);


            //modelBuilder.Entity<Chat>()
            //    .HasMany(u => u.Users)
            //    .WithMany(u => u.Chats);




        }

    }
}
