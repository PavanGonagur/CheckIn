using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelUserModel
    {
        public int ChannelId { get; set; }

        [DisplayName("Email Ids")]
        public string UserEmailIds { get; set; }

        [DisplayName("Added Users")]
        public List<ChannelUser> AddedUsers { get; set; }

        public ChannelUserModel()
        {
            AddedUsers = new List<ChannelUser>();
        }

        public ChannelUserModel(int id)
        {
            ChannelId = id;
            AddedUsers = new List<ChannelUser>();
        }
    }
}