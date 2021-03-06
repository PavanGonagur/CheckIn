﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class LocationModel
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public LocationModel()
        {
            
        }

        public LocationModel(CheckIn.Data.Entities.Location location)
        {
            this.Longitude = location.Longitude;
            this.Latitude = location.Latitude;
            this.LocationName = location.LocationName;
            this.LocationId = location.LocationId;
        }

        public CheckIn.Data.Entities.Location ToEntity()
        {
            var location = new CheckIn.Data.Entities.Location()
                               {
                                   LocationId = this.LocationId,
                                   Longitude = this.Longitude,
                                   Latitude = this.Latitude,
                                   LocationName = this.LocationName
                               };
            return location;
        }
    }
}