using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.Location
{
    public class LocationEditModel
    {
        public int ChannelId { get; set; }

        public int LocationId { get; set; }

        [Required]
        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [Required]
        [DisplayName("Latitude")]
        public float Latitude { get; set; }

        [Required]
        [DisplayName("Longitude")]
        public float Longitude { get; set; }

        public LocationEditModel()
        {
            
        }

        public LocationEditModel ToModel(CheckIn.Data.Entities.Location location)
        {
            this.Longitude = location.Longitude;
            this.Latitude = location.Latitude;
            this.LocationName = location.LocationName;
            this.LocationId = location.LocationId;
            this.ChannelId = location.ChannelId;
            return this;
        }

        public CheckIn.Data.Entities.Location ToEntity()
        {
            var location = new CheckIn.Data.Entities.Location()
            {
                ChannelId = ChannelId,
                LocationId = this.LocationId,
                Longitude = this.Longitude,
                Latitude = this.Latitude,
                LocationName = this.LocationName
            };
            return location;
        }
    }
}