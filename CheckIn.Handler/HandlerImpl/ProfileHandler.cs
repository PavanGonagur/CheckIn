using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using System.Data.Entity.Migrations;

    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    public class ProfileHandler : IProfileHandler
    {
        private readonly CheckInDb checkInDb;
        public ProfileHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        #region Profiles

        public int AddOrUpdateProfile(Profile profile)
        {
            this.checkInDb.Profiles.AddOrUpdate(profile);
            if (profile.ProfileId > 0)
            {
                foreach (var profileKeyValue in profile.Data)
                {
                    AddOrUpdateProfileKeyValue(profileKeyValue);
                }
            }
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.Profiles
                        orderby r.ProfileId descending
                        select r;
            if (query.Any())
            {
                return query.First().ProfileId;
            }
            return 0;
        }

        public List<Profile> RetrieveProfilesByChannelId(int channelId)
        {
            var query = this.checkInDb.Profiles.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public Profile RetrieveProfileById(int profileId)
        {
            var query = this.checkInDb.Profiles.Where(x => x.ProfileId == profileId);
            if (query.Any())
            {
                var currentProfile = query.FirstOrDefault();
                if (currentProfile != null)
                {
                    return currentProfile;
                }
            }
            return null;
        }

        public void DeleteProfile(Profile profile)
        {
            this.checkInDb.Profiles.Remove(profile);
            this.checkInDb.SaveChanges();
        }

        #endregion

        #region ProfileKeyValue

        public int AddOrUpdateProfileKeyValue(ProfileKeyValue profileKeyValue)
        {
            this.checkInDb.ProfileKeyValues.AddOrUpdate(profileKeyValue);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.ProfileKeyValues
                        orderby r.ProfileKeyValueId descending
                        select r;
            if (query.Any())
            {
                return query.First().ProfileKeyValueId;
            }
            return 0;
        }

        public List<ProfileKeyValue> RetrieveProfileKeyValuesByProfileId(int profileId)
        {
            var query = this.checkInDb.ProfileKeyValues.Where(x => x.ProfileId == profileId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }
        
        public void DeleteProfileKeyValue(ProfileKeyValue profileKeyValue)
        {
            this.checkInDb.ProfileKeyValues.Remove(profileKeyValue);
            this.checkInDb.SaveChanges();
        }

        #endregion
    }
}
