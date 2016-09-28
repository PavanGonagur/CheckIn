using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Data;

namespace CheckIn.Web.Models.Channel.Profile
{
    public abstract class BaseProfileModel
    {
        public int ProfileId { get; set; }

        public int ChannelId { get; set; }

        public ProfileType ProfileType { get; set; }
    }
}