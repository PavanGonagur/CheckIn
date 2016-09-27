using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IProfileHandler
    {
        int AddOrUpdateProfile(Profile profile);

        List<Profile> RetrieveProfilesByChannelId(int ChannelId);

        Profile RetrieveProfileById(int profileId);

        void DeleteProfile(Profile profile);

        int AddOrUpdateProfileKeyValue(ProfileKeyValue profileKeyValue);

        List<ProfileKeyValue> RetrieveProfileKeyValuesByProfileId(int profileId);

        void DeleteProfileKeyValue(ProfileKeyValue profileKeyValue);
    }
}
