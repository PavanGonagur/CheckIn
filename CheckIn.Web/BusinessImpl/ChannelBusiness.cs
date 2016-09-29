using System;
using System.Collections.Generic;
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
                                  TimeOfActivation = channelModel.TimeOfActivation.ToString(),
                                  TimeOfDeactivation = channelModel.TimeOfDeactivation.ToString(),
                              };
            return this.channelHandler.AddChannel(channel);
        }

        public ChannelListModel RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId)
        {
            var channels = this.channelHandler.RetrieveChannelsByLocationAndUser(latitude, longitude, userId);
            if (channels != null && channels.Count > 0)
            {
                var channelListModel = new ChannelListModel();
                var channelsDummy = channels.Select(channel => new ChannelModelResponse(channel) { IsAuthenticated = channel.IsPublic ? true : channel.UserChannelMaps.Single(x => x.UserId == userId).Otp == null }).ToList();
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

        public List<Channel> GetChannelsForAdmin(int adminId)
        {
            if (SessionUtility.CurrentAdmin.IsSuperAdmin)
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