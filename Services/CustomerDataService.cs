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
    public class CustomerDataService
    {
        private readonly SocialiazerDBContext socialiazerDBContext;
        public CustomerDataService(SocialiazerDBContext db)
        {
            socialiazerDBContext = db;
        }

        public async Task<Customer> GetCustomerData(int Id)
        {
            return await socialiazerDBContext.Customers.FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<List<Customer>> GetAllCustomersDatas()
        {
            return await socialiazerDBContext.Customers.ToListAsync();
        }
        public async Task<String> GetCustomerWalletAddress(int Id)
        {
            Customer cr = await GetCustomerData(Id);
            return cr.WalletAddress;
        }
        public async Task<List<Order>> GetAllCustomerOrders(int Id)
        {
            Customer cr = await GetCustomerData(Id);
            return cr.Orders.ToList();
        }

    }
}
