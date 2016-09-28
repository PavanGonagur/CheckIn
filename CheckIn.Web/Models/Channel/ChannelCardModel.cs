using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Data;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelCardModel
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public bool IsLocationBased { get; set; }

        public int Users { get; set; }

        public bool WifiProfile { get; set; }

        public bool RingerProfile { get; set; }

        public int Applications { get; set; }

        public int WebClips { get; set; }

        public int Contacts { get; set; }

        public ChannelCardModel ToModel(CheckIn.Data.Entities.Channel channel)
        {
            ChannelId = channel.ChannelId;
            Name = channel.Name;
            IsPublic = channel.IsPublic;
            IsLocationBased = channel.IsLocationBased;
            Users = channel.UserChannelMaps.Count + channel.UserEmailChannels.Count;
            WifiProfile = channel.Profiles.ToList().Exists(x => x.Type == ProfileType.WiFi);
            RingerProfile = channel.Profiles.ToList().Exists(x => x.Type == ProfileType.Silent);
            Applications = channel.Applications.Count;
            WebClips = channel.WebClips.Count;
            Contacts = channel.Contacts.Count;
            return this;
        }
    }
}