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
    using CheckIn.Web.Models;

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
    }
}