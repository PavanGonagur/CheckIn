using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Web.BusinessImpl;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelListModel
    {
        public List<ChannelCardModel> Channels { get; set; }

        public ChannelListModel()
        {
            Channels = new List<ChannelCardModel>();
        }

        public ChannelListModel Fetch(int id, string searchText = "")
        {
            var channels = new ChannelBusiness().GetChannelsForAdmin(id);
            foreach (var channel in channels)
            {
                Channels.Add(new ChannelCardModel().ToModel(channel));
            }
            return this;
        }
    }
}