using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    public class ChatHandler: IChatHandler
    {
        private readonly CheckInDb checkInDb;
        public ChatHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddChatRoom(ChatRoom chatRoom)
        {
            this.checkInDb.ChatRooms.Add(chatRoom);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.ChatRooms
                        orderby r.ChatRoomId descending
                        select r;
            if (query.Any())
            {
                return query.First().ChatRoomId;
            }
            return 0;
        }

        public ChatRoom RetrieveChatRoom(int chatRoomId)
        {
            var query = this.checkInDb.ChatRooms.Where(x => x.ChannelId == chatRoomId);
            if (query.Any())
            {
                var currentUser = query.FirstOrDefault();
                if (currentUser != null)
                {
                    return currentUser;
                }
            }
            return null;
        }

        public int AddChatMessage(ChatMessage chatMessage)
        {
            this.checkInDb.ChatMessages.Add(chatMessage);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.ChatMessages
                        orderby r.ChatMessageId descending
                        select r;
            if (query.Any())
            {
                return query.First().ChatMessageId;
            }
            return 0;
        }

        public List<ChatMessage> RetrieveChatMessagesByChannelId(int channelId)
        {
            var messages = this.checkInDb.ChatMessages.Where(x => x.ChatRoomId == channelId);
            if (messages != null)
            {
                return messages.ToList();
            }
            return null;
        }
    }
}
