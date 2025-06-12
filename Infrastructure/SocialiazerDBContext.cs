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
        public DbSet<Crypto> Cryptocurrencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(m => m.messages)
                .WithOne(m => m.chat)
                .HasForeignKey(m => m.ChatId);
            modelBuilder.Entity<Chat>().HasKey(c => c.Id);
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            modelBuilder.Entity<Chat>().Property(m => m.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Crypto>()
               .Property(c => c.Price)
               .HasPrecision(18, 4);
           
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 4);
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Quantity)
                .HasPrecision(18, 8);
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 4);
        }
    }
}
