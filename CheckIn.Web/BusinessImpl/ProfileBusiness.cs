using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Data;
using CheckIn.Web.Models.Channel.Profile;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Channel;

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

        public List<Profile> RetrieveProfilesByChannelId(int channelId)
        {
            var profiles = this.profileHandler.RetrieveProfilesByChannelId(channelId);
            /*if (profiles != null)
            {
                var profileModelList = profiles.Select(x => new ProfileModel(x)).ToList();
                return profileModelList;
            }*/
            return profiles;
        }

        public BaseProfileModel BuildProfileModel(int channelId, ProfileType type)
        {
            if (type == ProfileType.WiFi)
            {
                var profiles = RetrieveProfilesByChannelId(channelId);
                var wifiProfile = profiles?.FirstOrDefault(x => x.Type == ProfileType.WiFi);
                
                return new WifiProfileModel(channelId, type).ToModel(wifiProfile);
            }
            return new WifiProfileModel(channelId, type);
        }
    }
}