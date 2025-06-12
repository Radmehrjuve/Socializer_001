using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDataService
    {
        private readonly SocialiazerDBContext socialiazerDBContext;
        public OrderDataService(SocialiazerDBContext db)
        {
            socialiazerDBContext = db;
        }

        public async Task<Order> GetOrderData(int Id)
        {
            return await socialiazerDBContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await socialiazerDBContext.Orders.ToListAsync();
        }

        public async Task AddOrder(Order order)
        {
            await socialiazerDBContext.Orders.AddAsync(order);
        }
        public async Task DeleteOrder(int Id)
        {
            Order order = await GetOrderData(Id);
            if (order != null)
            {
                socialiazerDBContext.Orders.Remove(order);
                await socialiazerDBContext.SaveChangesAsync();
            }
        }
        public async Task UpdateOrder(Order order)
        {
            Order or = await GetOrderData(order.Id);
            if (order != null)
            {
                or.TotalAmount = order.TotalAmount;
                or.OrderDate = order.OrderDate;
                or.Status = order.Status;
                or.Items = order.Items;
                await socialiazerDBContext.SaveChangesAsync();
            }
        }
    }
}
