using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}