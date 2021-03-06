﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Data.Entities;

namespace CheckIn.Web.Business
{
    using CheckIn.Web.Models;
    using CheckIn.Web.Models.Channel;

    public interface IChannelBusiness
    {
        int AddChannel(ChannelViewModel channelModel);

        ChannelModel GetChannelOnText(string searchText);
        ChannelListModel RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId);

        ChannelViewModel GetChannel(int channelId);

        List<Channel> GetChannelsForAdmin(int adminId);

        Channel RetrieveChannelById(int channelId);

        void DeleteChannel(Channel channel);

        int AddBrandingForChannel(ChannelBrandingModel channelBrandingModel);

        ChannelBrandingModel RetrieveChannelBrandingByChannelId(int id);
    }
}
