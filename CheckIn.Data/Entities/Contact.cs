using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        public string ContactName { get; set; }

        public string Title { get; set; }

        public string ContactNumber { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
