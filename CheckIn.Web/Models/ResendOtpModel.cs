using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class ResendOtpModel
    {
        [JsonProperty("CheckInServerUserId")]
        public int CheckInServerUserId { get; set; }

        [JsonProperty("ChannelId")]
        public int ChannelId { get; set; }
    }
}