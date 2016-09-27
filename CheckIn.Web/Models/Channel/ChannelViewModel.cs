using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelViewModel
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool IsLocationBased { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public DateTime TimeOfActivation { get; set; }

        public DateTime TimeOfDeactivation { get; set; }
    }
}