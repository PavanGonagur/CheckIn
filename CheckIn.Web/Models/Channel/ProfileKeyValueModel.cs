using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Channel
{
    using CheckIn.Data.Entities;

    public class ProfileKeyValueModel
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public ProfileKeyValueModel(ProfileKeyValue profileKeyValue)
        {
            this.Key = profileKeyValue.Key;
            this.Value = profileKeyValue.Value;
        }

        public ProfileKeyValue ToEntity()
        {
            var profile = new ProfileKeyValue()
                              {
                                  Key = this.Key,
                                  Value = this.Value
                              };
            return profile;
        }
    }
}