﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.Application
{
    using System.ComponentModel.DataAnnotations;

    public class ApplicationEditModel
    {
        public int ChannelId { get; set; }

        public int ApplicationId { get; set; }

        [Required]
        [DisplayName("Application Name")]
        public string ApplicationName { get; set; }

        [Required]
        [DisplayName("Application Store Link")]
        public string ApplicationUrl { get; set; }

        public ApplicationEditModel()
        {

        }

        public ApplicationEditModel ToModel(CheckIn.Data.Entities.Application entity)
        {
            ApplicationId = entity.ApplicationId;
            ApplicationName = entity.ApplicationName;
            ApplicationUrl = entity.ApplicationUrl;
            ChannelId = entity.ChannelId;
            return this;
        }

        public CheckIn.Data.Entities.Application ToEntity()
        {
            var application = new CheckIn.Data.Entities.Application()
            {
                ChannelId = ChannelId,
                ApplicationId = this.ApplicationId,
                ApplicationName = this.ApplicationName,
                ApplicationUrl = this.ApplicationUrl
            };
            return application;
        }
    }
}