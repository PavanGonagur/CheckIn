using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class UserChannelMapModel
    {
        [JsonProperty("Emails")]
        public List<string> Emails { get; set; }

        [JsonProperty("ChannelId")]
        public int ChannelId { get; set; }
    }
}