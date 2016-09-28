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
        public OTP Otp { set; get; }
    }

    public class OTP
    {
        [JsonProperty("Token")]
        public string Token { get; set; }

        [JsonProperty("UserID")]
        public int CheckInServerUserId { get; set; }

        [JsonProperty("ChannelId")]
        public int ChannelId { get; set; }
    }
}