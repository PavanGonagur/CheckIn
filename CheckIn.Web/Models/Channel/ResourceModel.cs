using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ResourceModel
    {
        public ICollection<ChatRoomModel> ChatRooms { get; set; }

        public ICollection<ProfileModel> Profiles { get; set; }

        public ICollection<WebClipModel> WebClips { get; set; }

        public ICollection<ApplicationModel> Applications { get; set; }

        public ICollection<LocationModel> Locations { get; set; }

        public ICollection<ContactModel> Contacts { get; set; }
    }
}