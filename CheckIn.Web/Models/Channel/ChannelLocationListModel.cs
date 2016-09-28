using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelLocationListModel
    {
        public ChannelLocationListModel()
        {
            Locations = new List<LocationModel>();
        }

        public ChannelLocationListModel(int id) : base()
        {
            ChannelId = id;
            Locations = new List<LocationModel>();
        }

        public int ChannelId { get; set; }

        public List<LocationModel> Locations { get; set; }
    }
}