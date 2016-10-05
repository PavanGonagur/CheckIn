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

        public ChatRoom RetrieveChatRoomByChannelId(int channelId)
        {
            var query = this.checkInDb.ChatRooms.Where(x => x.ChannelId == channelId);
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

        public void DeleteChatRoom(ChatRoom chatRoom)
        {
            this.checkInDb.ChatRooms.Remove(chatRoom);
            this.checkInDb.SaveChanges();
        }

        public void DeleteChatMessage(ChatMessage chatMessage)
        {
            this.checkInDb.ChatMessages.Remove(chatMessage);
            this.checkInDb.SaveChanges();
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

        public List<string> RetrieveRegistrationIds(int chatRoomId,int? userId)
        {
            var query = from userid in (from cr in this.checkInDb.ChatRooms
                                        join uc in this.checkInDb.UserChannelMaps on cr.ChannelId equals uc.ChannelId
                                        where cr.ChatRoomId == chatRoomId
                                        select uc.UserId)
                        join user in this.checkInDb.Users on userid equals user.UserId
                        where user.UserId != userId
                        select user.RegistrationId;
            if (query.Any())
            {
                return query.ToList();
            }
            return null;

        }
    }
}
