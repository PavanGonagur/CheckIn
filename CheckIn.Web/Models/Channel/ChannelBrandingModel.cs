using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Data.Entities;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelBrandingModel
    {
        public int ChannelBrandingId { get; set; }

        public string IconUrl { get; set; }

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }

        public string TertiaryColor { get; set; }

        public int ChannelId { get; set; }

        public ChannelBrandingModel(ChannelBranding channelBranding)
        {
            this.ChannelBrandingId = channelBranding.ChannelBrandingId;
            this.IconUrl = channelBranding.IconUrl;
            this.ChannelId = channelBranding.ChannelId;
            this.PrimaryColor = channelBranding.PrimaryColor;
            this.SecondaryColor = channelBranding.SecondaryColor;
            this.TertiaryColor = channelBranding.TertiaryColor;

        }

        public ChannelBrandingModel()
        {
            
        }
    }
}