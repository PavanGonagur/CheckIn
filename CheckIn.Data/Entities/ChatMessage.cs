using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }

        public int ChatRoomId { get; set; }

        public int? UserId { get; set; }

        public string Message { get; set; }

        public bool IsAdminMessage { get; set; }

        public bool IsImage { get; set; }

        public string TimeOfGeneration { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }

        public virtual User User { get; set; }
    }
}
