using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data;
    using CheckIn.Data.Entities;

    using WebGrease.Css.Extensions;

    public class ProfileModel
    {
        public int ProfileId { get; set; }
        
        public ProfileType Type { get; set; }
        
        public ICollection<ProfileKeyValueModel> Data { get; set; }

        public ProfileModel()
        {
            
        }

        public ProfileModel(Profile profileEntity)
        {
            ProfileId = profileEntity.ProfileId;
            Type = profileEntity.Type;
            Data = profileEntity.Data.Select(x => new ProfileKeyValueModel(x)).ToList();
        }

        public Profile ToEntity()
        {
            var profile = new Profile()
                              {
                                  ProfileId = this.ProfileId,
                                  Type = this.Type,
                                  Data = this.Data.Select(x => x.ToEntity()).ToList()
                              };
            return profile;
        }
    }
}