using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Channel
    {
        public int ChannelId { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public bool IsLocationBased { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public string TimeOfActivation { get; set; }

        public string TimeOfDeactivation { get; set; }

        public string Description { get; set; }

        public virtual ICollection<AdminChannelMap> AdminChannelMaps { get; set; }

        public virtual ICollection<UserChannelMap> UserChannelMaps { get; set; }

        public virtual ICollection<UserEmailChannel> UserEmailChannels { get; set; }

        public virtual ICollection<ChatRoom> ChatRooms { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

        public virtual ICollection<WebClip> WebClips { get; set; }

        public virtual ICollection<Application> Applications { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
