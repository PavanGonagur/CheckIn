using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    public class RegisterToChannelResponseModel
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public bool IsLocationBased { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}