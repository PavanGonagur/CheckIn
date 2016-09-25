using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class UpdateUserRegistrationModel
    {
        //CheckInServerUserId from CheckIn Server
        [JsonProperty("CheckInServerUserId")]
        public int CheckInServerUserId { get; set; }
        [JsonProperty("RegistrationId")]
        public string RegistrationId { get; set; }
    }
}