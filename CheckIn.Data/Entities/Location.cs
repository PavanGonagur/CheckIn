using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
