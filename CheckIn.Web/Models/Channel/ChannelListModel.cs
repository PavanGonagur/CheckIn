using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Web.BusinessImpl;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelListModel
    {
        public List<ChannelModelResponse> Channels { get; set; }

        public List<ChannelCardModel> ChannelCardModels { get; set; }

        public ChannelListModel()
        {
            ChannelCardModels = new List<ChannelCardModel>();
        }

        public ChannelListModel Fetch(int id, string searchText = "")
        {
            var channels = new ChannelBusiness().GetChannelsForAdmin(id);
            if (channels != null)
            {
                foreach (var channel in channels)
                {
                    ChannelCardModels.Add(new ChannelCardModel().ToModel(channel));
                }
            }
            
            return this;
        }
    }
}