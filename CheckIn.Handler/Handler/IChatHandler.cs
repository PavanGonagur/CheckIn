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

        ChatRoom RetrieveChatRoom(int chatRoomId);

        int AddChatMessage(ChatMessage chatMessage);

        List<ChatMessage> RetrieveChatMessagesByChannelId(int channelId);
    }
}
