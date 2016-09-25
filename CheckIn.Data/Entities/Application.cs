using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }

        public string ApplicationUrl { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
