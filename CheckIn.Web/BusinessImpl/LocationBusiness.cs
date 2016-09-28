using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Channel;

    public class LocationBusiness : ILocationBusiness
    {
        private readonly ILocationHandler locationHandler;

        public LocationBusiness()
        {
            this.locationHandler = new LocationHandler();
        }

        public int AddLocation(Location location)
        {
            var exsitingLocationId = this.locationHandler.AddOrUpdateLocation(location);
            if (location.LocationId != 0)
            {
                return location.ChannelId;
            }
            return exsitingLocationId;
        }

        public void DeleteLocationn(Location location)
        {
            this.locationHandler.DeleteLocation(location);
        }

        //if profile not present returning null
        public Location RetrieveLocationById(int locationId)
        {
            return this.locationHandler.RetrieveLocationById(locationId);
        }

        public List<LocationModel> RetrieveLocationsByChannelId(int channelId)
        {
            var locations = this.locationHandler.RetrieveLocationsByChannelId(channelId);
            if (locations != null)
            {
                var locationModelList = locations.Select(x => new LocationModel(x)).ToList();
                return locationModelList;
            }
            return null;
        }
    }
}