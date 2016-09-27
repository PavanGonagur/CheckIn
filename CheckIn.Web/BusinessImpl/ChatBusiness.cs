using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Channel;
    using CheckIn.Web.Models.Chat;
    using CheckIn.Web.Utilities;
    using CheckIn.Web.Utilities.Interface;

    using Newtonsoft.Json;

    public class ChatBusiness:IChatBusiness
    {
        private IChatHandler chatHandler;

        private INotification fcmNotification;

        private IChannelHandler channelHandler;

        private IUserHandler userHandler;

        private IUserChannelMapHandler userChannelMapHandler;

        public ChatBusiness()
        {
            this.chatHandler = new ChatHandler();
            this.fcmNotification = new FcmNotification();
            this.channelHandler = new ChannelHandler();
            this.userHandler = new UserHandler();
            this.userChannelMapHandler = new UserChannelMapHandler();

        }
        public void AddChatMessage(ChatMessageModel chatMessageMessageModel)
        {
            if (chatMessageMessageModel.IsImage)
            {
                //Image Handling
            }
            var chatMessage = new ChatMessage()
                                  {
                                      ChatRoomId = chatMessageMessageModel.ChatRoomId,
                                      IsImage = chatMessageMessageModel.IsImage,
                                      Message = chatMessageMessageModel.Message,
                                      IsAdminMessage = chatMessageMessageModel.IsAdminMessage,
                                      TimeOfGeneration = chatMessageMessageModel.TimeOfGeneration,
                                      UserId = chatMessageMessageModel.UserId
                                  };
           
            var chatMessageId = this.chatHandler.AddChatMessage(chatMessage);
            var registrationIds = this.chatHandler.RetrieveRegistrationIds(chatMessageMessageModel.ChatRoomId, chatMessageMessageModel.UserId);
            chatMessageMessageModel.ChatMessageId = chatMessageId;
            var fcmPayload = new FcmPayload() { Data = chatMessageMessageModel, RegistrationIds = registrationIds };
            var json = JsonConvert.SerializeObject(fcmPayload);
            this.fcmNotification.SendNotification(json);
        }
        
    }
}