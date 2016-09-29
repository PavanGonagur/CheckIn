using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Business
{
    using CheckIn.Web.Models.Channel;

    public interface IChatBusiness
    {
        void AddChatMessage(ChatMessageModel chatMessage);

        int AddChatRoom(ChatRoomModel chatRoomModel);
    }
}