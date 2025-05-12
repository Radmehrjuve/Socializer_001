using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure
{
    public interface IEFOpertaions
    {
        Task<Chat?> GetChatInfo(int chatid);
        Task<List<Chat>> GetAllChats(int userid);
        Task AddChat(Chat chat);
        Task DeleteChat(int chatid);
        Task UpdateChat(Chat chat);
        Task<List<Message>> GetMessages(int chatid);
        Task AddMesasge(Message message);
    }
}
