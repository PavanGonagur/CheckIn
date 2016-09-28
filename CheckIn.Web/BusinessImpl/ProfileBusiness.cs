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

    public class ProfileBusiness : IProfileBusiness
    {
        private readonly IProfileHandler profileHandler;

        public ProfileBusiness()
        {
            this.profileHandler = new ProfileHandler();
        }

        public int AddProfile(Profile profile)
        {
            var exsitingUserId = this.profileHandler.AddOrUpdateProfile(profile);
            if (profile.ProfileId != 0)
            {
                return profile.ProfileId;
            }
            return exsitingUserId;
        }

        public void DeleteProfile(Profile application)
        {
            this.profileHandler.DeleteProfile(application);
        }

        //if profile not present returning null
        public Profile RetrieveProfileById(int profileId)
        {
            return this.profileHandler.RetrieveProfileById(profileId);
        }
    }
}