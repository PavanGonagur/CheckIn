﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Utilities;

    public class ChatMessageModel
    {
        public int ChatMessageId { get; set; }

        public int ChatRoomId { get; set; }

        public int? UserId { get; set; }

        public string Message { get; set; }

        public bool IsAdminMessage { get; set; }

        public bool IsImage { get; set; }

        public byte[] ImageArray { get; set; }

        public string TimeOfGeneration { get; set; }

        public string UserName { get; set; }

        public ChatMessageModel()
        {
            
        }

        public ChatMessageModel(ChatMessage chatMessage)
        {
            this.ChatMessageId = chatMessage.ChatMessageId;
            this.UserId = chatMessage.IsAdminMessage ? 0 : chatMessage.UserId;
            this.ChatRoomId = chatMessage.ChatRoomId;
            this.IsAdminMessage = chatMessage.IsAdminMessage;
            this.Message = chatMessage.Message;
            this.TimeOfGeneration = chatMessage.TimeOfGeneration;
            this.IsImage = chatMessage.IsImage;
            this.UserName = chatMessage.IsAdminMessage ? "Admin" : chatMessage.User?.Name ?? "Bot";
        }

        public ChatMessage ToEntity()
        {
            var chatMessage = new ChatMessage()
                                  {
                                      ChatMessageId = this.ChatMessageId,
                                      ChatRoomId = this.ChatRoomId,
                                      IsImage = this.IsImage,
                                      IsAdminMessage = this.IsAdminMessage,
                                      TimeOfGeneration = this.TimeOfGeneration,
                                      Message = this.Message,
                                      UserId = this.UserId
                                  };
            return chatMessage;
        }
    }
}