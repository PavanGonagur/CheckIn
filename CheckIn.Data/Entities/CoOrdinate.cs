using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Data.Entities
{
    public class Coordinate
    {
        public int CoordinateId { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
