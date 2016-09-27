using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Chat
{
    using Newtonsoft.Json;

    public class FcmPayload
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("registration_ids")]
        public List<string> RegistrationIds { get; set; }

    }
}