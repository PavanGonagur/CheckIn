using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelUser
    {
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }
    }
}