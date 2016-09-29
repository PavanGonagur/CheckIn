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
    using CheckIn.Web.Common;
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
        public void AddChatMessage(ChatMessageModel chatMessageModel)
        {
            if (chatMessageModel.IsImage)
            {
                var fileName = ImageUtility.UploadAndGetFileName(chatMessageModel.ImageArray);
                chatMessageModel.Message = Constants.ServerUrl + "MyImages/ChatMessage/" + fileName;
            }
            var chatMessage = new ChatMessage()
                                  {
                                      ChatRoomId = chatMessageModel.ChatRoomId,
                                      IsImage = chatMessageModel.IsImage,
                                      Message = chatMessageModel.Message,
                                      IsAdminMessage = chatMessageModel.IsAdminMessage,
                                      TimeOfGeneration = chatMessageModel.TimeOfGeneration,
                                      UserId = chatMessageModel.UserId
                                  };
           
            var chatMessageId = this.chatHandler.AddChatMessage(chatMessage);
            var registrationIds = this.chatHandler.RetrieveRegistrationIds(chatMessageModel.ChatRoomId, chatMessageModel.UserId);
            chatMessageModel.ChatMessageId = chatMessageId;
            var fcmPayload = new FcmPayload() { Data = chatMessageModel, RegistrationIds = registrationIds };
            var json = JsonConvert.SerializeObject(fcmPayload);
            this.fcmNotification.SendNotification(json);
        }

        public int AddChatRoom(ChatRoomModel chatRoomModel)
        {
            var chatRoom = chatRoomModel.ToEntity();
            var chatRoomId = this.chatHandler.AddChatRoom(chatRoom);
            return chatRoomId;
        }
    }
}