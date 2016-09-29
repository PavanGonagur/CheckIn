using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using CheckIn.Web.Utilities;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Channel;

    using ChannelModel = CheckIn.Web.Models.ChannelModel;

    public class ChannelBusiness : IChannelBusiness
    {
        private IChannelHandler channelHandler;

        public ChannelBusiness()
        {
            this.channelHandler = new ChannelHandler();
        }
        public int AddChannel(ChannelViewModel channelModel)
        {
            var channel = new Channel()
                              {
                                  IsLocationBased = channelModel.IsLocationBased,
                                  IsPublic = channelModel.IsPublic,
                                  Name = channelModel.Name,
                                  ChannelId = channelModel.ChannelId,
                                  Description = channelModel.Description,
                                  Latitude = channelModel.Latitude,
                                  Longitude = channelModel.Longitude,
                                  TimeOfActivation = channelModel.TimeOfActivation.ToString("dd-MM-yyyy HH:mm:ss"),
                                  TimeOfDeactivation = channelModel.TimeOfDeactivation.ToString("dd-MM-yyyy HH:mm:ss"),
                              };
            if (channel.ChannelId == 0)
            {
                channel.ChatRooms = new List<ChatRoom>
                {
                    new ChatRoom
                    {
                        Name = channel.Name + "Chat Room",
                        ChatMessage = new List<ChatMessage>
                        {
                            new ChatMessage
                            {
                                IsAdminMessage = true,
                                Message = "Welcome to " + channel.Name,
                                IsImage = false,
                                TimeOfGeneration = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                            }
                        }
                    }
                };
                return this.channelHandler.AddChannel(channel);
            }
            this.channelHandler.UpdateChannel(channel);
            return channel.ChannelId;
        }

        public ChannelListModel RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId)
        {
            var channels = this.channelHandler.RetrieveChannelsByLocationAndUser(latitude, longitude, userId);
            if (channels != null && channels.Count > 0)
            {
                var channelListModel = new ChannelListModel();
                var channelsDummy = channels.Select(channel => new ChannelModelResponse(channel) { IsAuthenticated = channel.UserChannelMaps.Single(x => x.UserId == userId).Otp == null }).ToList();
                channelListModel.Channels = channelsDummy;
                return channelListModel;
                /*return new ChannelListModel()
                {
                    Channels = channels.Select(x => new ChannelModelResponse(x)).ToList()
                };*/
            }
            return null;
        }


        private ChannelListModel RetrieveChannelsByAdmin(int adminId)
        {
            var channels = this.channelHandler.RetrieveChannelsOnAdmin(adminId);
            if (channels != null)
            {
                ChannelListModel channelListModel = new ChannelListModel()
                                                        {
                                                            Channels =
                                                                channels.Select(
                                                                    x => new ChannelModelResponse(x))
                                                                .ToList()
                                                        };
                return channelListModel;
            }
            return new ChannelListModel();
        }

        public ChannelModel GetChannelOnText(string searchText)
        {
            var channel = this.channelHandler.GetChannelOnText(searchText);
            if (channel != null)
            {
                var channelModel = new ChannelModel(channel);
                return channelModel;
            }
            return null;
        }

        public ChannelViewModel GetChannel(int channelId)
        {
            var channel = this.channelHandler.RetrieveChannel(channelId);
            if (channel != null)
            {
                var channelModel = new ChannelViewModel
                {
                    IsLocationBased = channel.IsLocationBased,
                    IsPublic = channel.IsPublic,
                    Name = channel.Name,
                    ChannelId = channel.ChannelId,
                    Description = channel.Description,
                    Latitude = channel.Latitude,
                    Longitude = channel.Longitude,
                    TimeOfActivation = DateTime.ParseExact(channel.TimeOfActivation, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                    TimeOfDeactivation = DateTime.ParseExact(channel.TimeOfDeactivation, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture)
                };
                return channelModel;
            }
            return null;
        }

        public List<Channel> GetChannelsForAdmin(int adminId)
        {
            var admin = new AdminBusiness().RetrieveAdmin(adminId);
            if (admin.IsSuperAdmin)
            {
                return channelHandler.RetrieveAllChannels();
            }
            else
            {
                //TODO Channels For Admin
                return channelHandler.RetrieveChannelsOnAdmin(adminId);
            }
        }
    }
}