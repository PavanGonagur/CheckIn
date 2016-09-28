using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class ChannelModel
    {
        public int ChannelId { get; set; }
        [JsonProperty("ChannelName")]
        public string Name { get; set; }

        [JsonProperty("IsPublic")]
        public bool IsPublic { get; set; }

        [JsonProperty("IsLocationBased")]
        public bool IsLocationBased { get; set; }

        [JsonProperty("Latitude")]
        public float Latitude { get; set; }

        [JsonProperty("Longitude")]
        public float Longitude { get; set; }

        public ChannelModel()
        {
            
        }

        public ChannelModel(CheckIn.Data.Entities.Channel channel)
        {
            this.Longitude = channel.Longitude;
            this.Latitude = channel.Latitude;
            this.IsLocationBased = channel.IsLocationBased;
            this.IsPublic = channel.IsPublic;
            this.Name = channel.Name;
            this.ChannelId = channel.ChannelId;
        }
    }
}