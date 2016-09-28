using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using System.Data.Entity.Migrations;

    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;

    public class LocationHandler : ILocationHandler
    {
        private readonly CheckInDb checkInDb;
        public LocationHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public int AddOrUpdateLocation(Location location)
        {
            this.checkInDb.Locations.AddOrUpdate(location);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Locations
                        orderby r.LocationId descending
                        select r;
            if (query.Any())
            {
                return query.First().LocationId;
            }
            return 0;
        }

        public List<Location> RetrieveLocationsByChannelId(int channelId)
        {
            var query = this.checkInDb.Locations.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public Location RetrieveLocationById(int locationId)
        {
            var query = this.checkInDb.Locations.Where(x => x.LocationId == locationId);
            if (query.Any())
            {
                var currentLocation = query.FirstOrDefault();
                if (currentLocation != null)
                {
                    return currentLocation;
                }
            }
            return null;
        }

        public void DeleteLocation(Location location)
        {
            this.checkInDb.Locations.Remove(location);
            this.checkInDb.SaveChanges();
        }
    }
}
