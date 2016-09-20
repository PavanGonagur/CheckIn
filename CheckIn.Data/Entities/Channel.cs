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

        public virtual ICollection<AdminChannelMap> AdminChannelMaps { get; set; }

        public virtual ICollection<UserChannelMap> UserChannelMaps { get; set; }

        public virtual ICollection<UserEmailChannel> UserEmailChannels { get; set; }
    }
}
