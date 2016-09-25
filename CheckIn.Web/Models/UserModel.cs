using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class UserModel
    {
        //CheckInServerUserId from CheckIn Server
        [JsonProperty("CheckInServerUserId")]
        public int CheckInServerUserId { get; set; }

        [JsonProperty("UserName")]
        public string Name { get; set; }

        [JsonProperty("RemotePhotoServerURL")]
        public string ProfilePhotoUrl { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("UserEmail")]
        public string Email { get; set; }

        //UserID from google
        //[JsonProperty("UserID")]
        //public string UserID { get; set; }

        [JsonProperty("UserPhoto")]
        public string UserPhoto { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
    }
}