using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class RegisterToChannelModel
    {
        [JsonProperty("OTP")]
        public string OTP { get; set; }

        [JsonProperty("CheckInServerUserId")]
        public int CheckInServerUserId { get; set; }
    }
}