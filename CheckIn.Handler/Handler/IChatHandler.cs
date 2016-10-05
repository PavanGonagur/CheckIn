using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IChatHandler
    {
        int AddChatRoom(ChatRoom chatRoom);

        ChatRoom RetrieveChatRoomByChannelId(int chatRoomId);

        int AddChatMessage(ChatMessage chatMessage);

        List<ChatMessage> RetrieveChatMessagesByChannelId(int channelId);

        List<string> RetrieveRegistrationIds(int chatRoomId,int? userId);

        void DeleteChatRoom(ChatRoom chatRoom);

        void DeleteChatMessage(ChatMessage chatMessage);
    }
}
