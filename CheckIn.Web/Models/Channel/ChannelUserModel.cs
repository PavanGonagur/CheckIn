using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelUserModel
    {
        public int ChannelId { get; set; }

        public string UserEmailIds { get; set; }

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