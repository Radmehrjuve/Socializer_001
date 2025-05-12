using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SocialiazerDBContext : DbContext
    {
        public SocialiazerDBContext(DbContextOptions<SocialiazerDBContext> options) : base(options) { }
        
        public DbSet<Chat> chats {  get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(m => m.messages)
                .WithOne(m => m.chat)
                .HasForeignKey(m => m.ChatId);
            modelBuilder.Entity<Chat>().HasKey(c => c.Id);
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            modelBuilder.Entity<Chat>().Property(m => m.Id).ValueGeneratedOnAdd();
        }
    }
}
