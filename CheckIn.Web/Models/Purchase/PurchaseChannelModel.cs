using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Purchase
{
    public class PurchaseChannelModel
    {
        public string AdminName { get; set; }

        public string Email { get; set; }

        public string ChannelName { get; set; }

        public bool IsPublic { get; set; }
    }
}