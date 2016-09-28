using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class ChatRoomModel
    {
        public int ChatRoomId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ChatMessageModel> ChatMessages { get; set; }

        public ChatRoomModel()
        {
            
        }

        public ChatRoomModel(ChatRoom chatRoom)
        {
            this.ChatRoomId = chatRoom.ChatRoomId;
            this.Name = chatRoom.Name;
            this.ChatMessages = chatRoom.ChatMessage.Select(x => new ChatMessageModel(x)).ToList();
        }

        public ChatRoom ToEntity()
        {
            var chatRoom = new ChatRoom()
                               {
                                   ChatRoomId = this.ChatRoomId,
                                   ChatMessage = this.ChatMessages.Select(x => x.ToEntity()).ToList(),
                                   Name = this.Name
                               };
            return chatRoom;
        }
    }
}