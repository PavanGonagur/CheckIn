using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class AddChannelResponse
    {
        [JsonProperty("ChannelId")]
        public string ChannelId { get; set; }
    }
}