using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class UserEmailChannel
    {
        public int UserEmailChannelId { get; set; }

        public string Email { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
