using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class RetireveChannelByLocationAndUserModel
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public int  UserId { get; set; }
    }
}