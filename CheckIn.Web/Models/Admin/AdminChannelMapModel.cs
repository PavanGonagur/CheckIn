using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Admin
{
    using CheckIn.Data.Entities;

    using Newtonsoft.Json;

    public class AdminChannelMapModel
    {
        [JsonProperty("AdminId")]
        public int AdminId { get; set; }

        [JsonProperty("ChannelId")]
        public int ChannelId { get; set; }

        public AdminChannelMap ToModel()
        {
            var adminChannelMap = new AdminChannelMap() { AdminId = this.AdminId, ChannelId = this.ChannelId };
            return adminChannelMap;
        }
        
    }
}