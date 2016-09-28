using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelContactListModel
    {
        public ChannelContactListModel()
        {
            Contacts = new List<ContactModel>();
        }

        public ChannelContactListModel(int id) : base()
        {
            ChannelId = id;
            Contacts = new List<ContactModel>();
        }

        public int ChannelId { get; set; }

        public List<ContactModel> Contacts { get; set; }
    }
}