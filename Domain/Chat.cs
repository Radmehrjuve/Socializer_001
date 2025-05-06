using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Chat
    {
        public int Id { get; set; } // ChatId
        public int UserId { get; set; } // Owner
        public string Name { get; set; } = string.Empty; // Optional chat name like "Health Bot" or "Finance Q&A"
        public DateTime? TimeStamp { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public List<Message> messages { get; set; }

    }
}
