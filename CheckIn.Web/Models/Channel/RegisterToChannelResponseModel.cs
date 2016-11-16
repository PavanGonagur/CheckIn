using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using CheckIn.Web.Models.Channel;

    using Newtonsoft.Json;

    public class RegisterToChannelResponseModel
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
        public ResourceModel Resources { get; set; }

        public ChannelBrandingModel ChannelBranding { get; set; }
    }
}