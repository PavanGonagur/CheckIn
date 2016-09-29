using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Admin
{
    public class AdminChannelModel
    {
        public int AdminId { get; set; }

        [DisplayName("Channel Name")]
        public string ChannelName { get; set; }

        [DisplayName("Channel Description")]
        public string ChannelDescription { get; set; }

        public AdminChannelModel()
        {
        }

        public AdminChannelModel(int id)
        {
            AdminId = id;
        }
    }
}