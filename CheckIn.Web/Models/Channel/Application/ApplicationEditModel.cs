using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel.Application
{
    public class ApplicationEditModel
    {
        public int ChannelId { get; set; }

        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }

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
                ApplicationId = this.ApplicationId,
                ApplicationName = this.ApplicationName,
                ApplicationUrl = this.ApplicationUrl
            };
            return application;
        }
    }
}