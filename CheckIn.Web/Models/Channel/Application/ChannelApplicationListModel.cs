using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CheckIn.Web.Models.Channel.Application
{
    public class ChannelApplicationListModel
    {
        public ChannelApplicationListModel()
        {
            Applications = new List<ApplicationModel>();
        }

        public ChannelApplicationListModel(int id) : base()
        {
            ChannelId = id;
            Applications = new List<ApplicationModel>();
        }

        public int ChannelId { get; set; }

        public List<ApplicationModel> Applications { get; set; }
    }
}