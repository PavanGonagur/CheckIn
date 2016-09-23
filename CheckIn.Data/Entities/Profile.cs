using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public int ChannelId { get; set; }

        public ProfileType Type { get; set; }

        public virtual Channel Channel { get; set; }

        public ICollection<ProfileKeyValue> Data { get; set; }
    }
}
