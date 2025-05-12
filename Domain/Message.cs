using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }

        public int Role { get; set; } // 0 user, 1 assisstant

        public string Content { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; }
        public Chat chat { get; set; }
    }
}
