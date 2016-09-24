using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class AddAdminResponse
    {
        [JsonProperty("AdminId")]
        public string AdminId { get; set; }
    }
}