using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    using Newtonsoft.Json;

    public class ChannelModelResponse
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public bool IsLocationBased { get; set; }

        public string TimeOfActivation { get; set; }

        public string TimeOfDeactivation { get; set; }

        public string Description { get; set; }

        [JsonProperty("Co-ordinates")]
        public List<CoordinatesModel> CoordinatesModel { get; set; }

        public bool IsAuthenticated { get; set; }

        public ChannelBrandingModel ChannelBranding { get; set; }
        public ChannelModelResponse()
        {
            
        }

        public ChannelModelResponse(Channel channel)
        {
            this.ChannelId = channel.ChannelId;
            this.Name = channel.Name;
            this.IsLocationBased = channel.IsLocationBased;
            this.IsPublic = channel.IsPublic;
            this.Description = channel.Description;
            this.TimeOfActivation = channel.TimeOfActivation;
            this.TimeOfDeactivation = channel.TimeOfDeactivation;
            this.CoordinatesModel = new List<CoordinatesModel>()
                                        {
                                            new CoordinatesModel()
                                                {
                                                    Longitude =
                                                        channel.Longitude,
                                                    Latitude =
                                                        channel.Latitude
                                                }
                                        };
            this.ChannelBranding = new ChannelBrandingModel(channel.Branding.FirstOrDefault());
        }
    }
}