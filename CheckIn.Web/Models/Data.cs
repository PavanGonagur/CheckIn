using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Data
    {
        [JsonProperty("data")]
        public string JsonDataResponse { get; set; }
    }
}