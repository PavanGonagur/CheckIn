using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelWebClipListModel
    {
        public ChannelWebClipListModel()
        {
            WebClips = new List<WebClipModel>();
        }

        public ChannelWebClipListModel(int id) : base()
        {
            ChannelId = id;
            WebClips = new List<WebClipModel>();
        }

        public int ChannelId { get; set; }

        public List<WebClipModel> WebClips { get; set; }
    }
}