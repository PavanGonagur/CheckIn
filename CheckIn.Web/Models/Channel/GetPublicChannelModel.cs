using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using Newtonsoft.Json;

    public class GetPublicChannelModel
    {
        [JsonProperty("UserID")]
        public int CheckInServerUserId { get; set; }

        [JsonProperty("ChannelId")]
        public int ChannelId { get; set; }
    }
}