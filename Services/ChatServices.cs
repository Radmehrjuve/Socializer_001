using Domain;
using Infrastructure;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ChatServices
    {
        private readonly IEFOpertaions entities;
        public ChatServices(IEFOpertaions en)
        {
            entities = en;
        }

        public async Task<Chat?> GetChatInfo(int chatid)
        {
            return await entities.GetChatInfo(chatid);
        }

        public async Task<List<Chat>> GetAllChats(int userid)
        {
            return await entities.GetAllChats(userid);
        }

        public async Task AddChat(Chat chat)
        {
            await entities.AddChat(chat);
        }

        public async Task DeleteChat(int chatid)
        {
            await entities.DeleteChat(chatid);
        }

        public async Task UpdateChat(Chat chat)
        {
            await entities.UpdateChat(chat);
        }

        public async Task<List<Message>> GetMessages(int chatid)
        {
            return await entities.GetMessages(chatid);
        }

        public async Task AddMesasge(Message message)
        {
            
            await entities.AddMesasge(message);
        }

    }
}
