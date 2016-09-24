using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class AddUserResponse
    {
        [JsonProperty("UserId")]
        public string UserId { get; set; }
    }
}