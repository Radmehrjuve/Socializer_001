using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderItemsDataService
    {
        private readonly SocialiazerDBContext socialiazerDBContext;
        public OrderItemsDataService(SocialiazerDBContext db)
        {
            socialiazerDBContext = db;
        }

        public async Task<OrderItem> GetOrderItem(int Id)
        {
            return await socialiazerDBContext.OrderItems.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<List<OrderItem>> GetAllOrderItem(int OrderId)
        {
            return await socialiazerDBContext.OrderItems.Where(x => x.OrderId == OrderId).ToListAsync(); ;
        }
        public async Task AddOrderItem(OrderItem orderItem)
        {
            await socialiazerDBContext.AddAsync(orderItem);
            await socialiazerDBContext.SaveChangesAsync();
        }
        public async Task DeleteOrderItem(int orderid)
        {
            OrderItem orderitem = await GetOrderItem(orderid);
            socialiazerDBContext.OrderItems.Remove(orderitem);
            await socialiazerDBContext.SaveChangesAsync();
        }
        public async Task UpdateOrderItem(OrderItem orderitem)
        {
            OrderItem oi = await GetOrderItem(orderitem.Id);
            if (oi != null)
            {
                oi.OrderId = orderitem.OrderId;
                oi.Order = orderitem.Order;
                oi.Cryptocurrency = orderitem.Cryptocurrency;
                oi.CryptocurrencyId = orderitem.CryptocurrencyId;
                oi.Quantity = orderitem.Quantity;
                oi.UnitPrice = orderitem.UnitPrice;
                oi.Network = orderitem.Network;
                await socialiazerDBContext.SaveChangesAsync();
            }
        }
    }
}
