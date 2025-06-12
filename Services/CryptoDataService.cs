using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CryptoDataService
    {
        private readonly SocialiazerDBContext socialiazerDBContext;
        public CryptoDataService(SocialiazerDBContext db)
        {
            socialiazerDBContext = db;
        }

        public async Task<Crypto> GetCryptoData(int Id)
        {
            return await socialiazerDBContext.Cryptocurrencies.FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<List<Crypto>> GetAllCrytosDatas()
        {
            return await socialiazerDBContext.Cryptocurrencies.ToListAsync();
        }
        public async Task<decimal> GetCryptoPrice(int Id)
        {
            Crypto cr = await socialiazerDBContext.Cryptocurrencies.FirstOrDefaultAsync(c => c.Id == Id);
            return cr.Price;
        }
        public async Task UpdateCryptoData(Crypto cr)
        {
            Crypto crypto = await GetCryptoData(cr.Id);
            if (crypto != null)
            {
                crypto.Price = cr.Price;
                crypto.Symbol = cr.Symbol;
                crypto.Name = cr.Name;
                await socialiazerDBContext.SaveChangesAsync();
            }
            else throw new ArgumentNullException(nameof(crypto));
        }
        public async Task DeleteCrypto(int Id)
        {
            Crypto crypto = await GetCryptoData(Id);
            socialiazerDBContext.Cryptocurrencies.Remove(crypto);
            await socialiazerDBContext.SaveChangesAsync();
        }
        public async Task AddCrypto(Crypto crypto)
        {
            crypto = await GetCryptoData(crypto.Id);
            if(crypto == null)
            {
                await socialiazerDBContext.AddAsync(crypto);
               await socialiazerDBContext.SaveChangesAsync();
            }
            else 
                throw new ArgumentNullException(nameof(crypto));
        }
    }
}
