using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    public class ChannelViewModel
    {
        public int ChannelId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayName("Public Channel")]
        public bool IsPublic { get; set; }

        [DisplayName("Location Based")]
        public bool IsLocationBased { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        [Required]
        [DisplayName("Time Of Activation")]
        public DateTime TimeOfActivation { get; set; }

        [Required]
        [DisplayName("Time Of Deactivation")]
        public DateTime TimeOfDeactivation { get; set; }

        public ChannelViewModel()
        {
            TimeOfActivation = DateTime.Now;
            TimeOfDeactivation = DateTime.Now;
        }
    }
}