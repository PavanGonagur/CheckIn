using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.Profile
{
    public class ProfileViewModel
    {
        public int ChannelId { get; set; }

        public int WifiProfileId { get; set; }

        public int RingerProfileId { get; set; }

        public ProfileViewModel Initialize(int channelId)
        {
            ChannelId = channelId;
            return this;
        }
    }
}