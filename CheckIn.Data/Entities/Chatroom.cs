using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class ChatRoom
    {
        public int ChatRoomId { get; set; }

        public int ChannelId { get; set; }

        public string Name { get; set; }

        public virtual Channel Channel { get; set; }

        public virtual ICollection<ChatMessage> ChatMessage { get; set; }
    }
}
