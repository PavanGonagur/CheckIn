using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Data;
using CheckIn.Web.Models.Channel.Profile;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models.Channel;

    public interface IProfileBusiness
    {
        int AddProfile(Profile profile);

        void DeleteProfile(Profile application);

        Profile RetrieveProfileById(int profileId);

        List<Profile> RetrieveProfilesByChannelId(int channelId);

        BaseProfileModel BuildProfileModel(int channelId, ProfileType type);
    }
}
