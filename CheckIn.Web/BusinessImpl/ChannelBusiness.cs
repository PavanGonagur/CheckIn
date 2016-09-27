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

    using ChannelModel = CheckIn.Web.Models.ChannelModel;

    public class ChannelBusiness : IChannelBusiness
    {
        private IChannelHandler channelHandler;

        public ChannelBusiness()
        {
            this.channelHandler = new ChannelHandler();
        }
        public int AddChannel(ChannelModel channelModel)
        {
            var channel = new Channel()
                              {
                                  IsLocationBased = channelModel.IsLocationBased,
                                  IsPublic = channelModel.IsPublic,
                                  Name = channelModel.Name,
                                  Latitude = channelModel.Latitude,
                                  Longitude = channelModel.Longitude
                              };
            return this.channelHandler.AddChannel(channel);
        }

        public ChannelListModel RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId)
        {
            var channels = this.channelHandler.RetrieveChannelsByLocationAndUser(latitude, longitude, userId);
            if (channels != null && channels.Count > 0)
            {
                return new ChannelListModel()
                {
                    Channels = channels.Select(x => new ChannelModelResponse(x)).ToList()
                };
            }
            return null;
        }


        public ChannelListModel RetrieveChannelsByAdmin(int adminId)
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
    }
}