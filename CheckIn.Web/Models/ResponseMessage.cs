using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    public class ResponseMessage
    {
        public Status Status { get; set; }
        public object Data { get; set; }
    }
}