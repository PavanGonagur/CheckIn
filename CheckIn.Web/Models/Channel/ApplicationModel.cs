using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class ApplicationModel
    {
        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }

        public string ApplicationUrl { get; set; }

        public ApplicationModel()
        {
            
        }

        public ApplicationModel(CheckIn.Data.Entities.Application application)
        {
            this.ApplicationId = application.ApplicationId;
            this.ApplicationName = application.ApplicationName;
            this.ApplicationUrl = application.ApplicationUrl;
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