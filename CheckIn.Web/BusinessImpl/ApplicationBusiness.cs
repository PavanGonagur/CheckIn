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

    public class ApplicationBusiness : IApplicationBusiness
    {
        private readonly IApplicationHandler applicationHandler;

        public ApplicationBusiness()
        {
            this.applicationHandler = new ApplicationHandler();
        }

        public int AddApplication(Application application)
        {
            var exsitingUserId = this.applicationHandler.AddOrUpdateApplication(application);
            if (application.ApplicationId != 0)
            {
                return application.ApplicationId;
            }
            return exsitingUserId;
        }

        public List<ApplicationModel> RetrieveApplicationsByChannelId(int channelId)
        {
            var applications = this.applicationHandler.RetrieveApplicationsByChannelId(channelId);
            if (applications != null)
            {
                var applicationModelList = applications.Select(x => new ApplicationModel(x)).ToList();
                return applicationModelList;
            }
            return null;
        }

        public void DeleteApplication(Application application)
        {
            this.applicationHandler.DeleteApplication(application);
        }

        //if app not present returning null
        public Application RetrieveApplicationById(int applicationId)
        {
            return this.applicationHandler.RetrieveApplicationById(applicationId);
        }


    }
}