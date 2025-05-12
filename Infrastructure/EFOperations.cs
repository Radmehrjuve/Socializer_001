using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EFOperations : IEFOpertaions
    {
        private readonly SocialiazerDBContext socialiazerDBContext;

        public EFOperations(SocialiazerDBContext db)
        {
                socialiazerDBContext = db;
        }

        public async Task<Chat?> GetChatInfo(int chatid)
        {
            return await socialiazerDBContext.chats.FirstOrDefaultAsync(x => x.Id == chatid);
        }

        public async Task<List<Chat>> GetAllChats(int userid)
        {
            return await socialiazerDBContext.chats.Where(e => e.UserId == userid).ToListAsync();
        }

        public async Task AddChat(Chat chat)
        {
            await socialiazerDBContext.chats.AddAsync(chat);
            await socialiazerDBContext.SaveChangesAsync();
        }
        public async Task DeleteChat(int chatid)
        {
            Chat? ch = await socialiazerDBContext.chats.FirstOrDefaultAsync(e => e.Id == chatid);
            await socialiazerDBContext.SaveChangesAsync();
        }
        public async Task UpdateChat(Chat chat)
        {
            Chat ch = new Chat();
                ch.UserId = chat.UserId;
                ch.Name = chat.Name;
                ch.AccessToken = chat.AccessToken;
                ch.TimeStamp = chat.TimeStamp;
                ch.messages = chat.messages;
                await socialiazerDBContext.SaveChangesAsync();
        }

        public async Task<List<Message>> GetMessages(int chatid)
        {
            return await socialiazerDBContext.Messages.Where(e => e.ChatId == chatid).OrderBy(e => e.Timestamp).ToListAsync();
        }

        public async Task AddMesasge(Message message)
        {
            await socialiazerDBContext.Messages.AddAsync(message);
            await socialiazerDBContext.SaveChangesAsync();
        }
    }
}
