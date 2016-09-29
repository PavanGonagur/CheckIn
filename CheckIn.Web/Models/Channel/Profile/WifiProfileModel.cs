using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CheckIn.Data;
using CheckIn.Data.Entities;

namespace CheckIn.Web.Models.Channel.Profile
{
    using CheckIn.Web.BusinessImpl;

    public class WifiProfileModel : BaseProfileModel
    {
        public WifiProfileModel()
        {
            
        }

        public WifiProfileModel(int id, ProfileType profileType)
        {
            ChannelId = id;
            ProfileType = profileType;
        }

        [Required]
        [DisplayName("ServiceSetIdentifierSsid")]
        public string ServiceSetIdentifier { get; set; }

        public bool AutoJoin { get; set; }

        public bool HiddenNetwork { get; set; }

        public int SecurityType { get; set; }

        public string Password { get; set; }

        public Dictionary<int, string> SecurityTypeValues()
        {
            Dictionary<int, string> securityTypeDropDown = new Dictionary<int, string>
            {
                { 0, "None" },
                { 1, "WEP" },
                { 2, "WPA" }
            };
            return securityTypeDropDown;
        }

        public override CheckIn.Data.Entities.Profile ToEntity()
        {
            var profile = new CheckIn.Data.Entities.Profile
            {
                ProfileId = ProfileId,
                ChannelId = ChannelId,
                Type = ProfileType.WiFi
            };
            if (profile.ProfileId > 0)
            {
                var existingProfile = new ProfileBusiness().RetrieveProfileById(profile.ProfileId);
                profile.Data = new List<ProfileKeyValue>
                {
                    new ProfileKeyValue
                    {
                        Key = "ServiceSetIdentifier",
                        Value = ServiceSetIdentifier,
                        ProfileId = profile.ProfileId,
                        ProfileKeyValueId = existingProfile.Data.First(x => x.Key == "ServiceSetIdentifier").ProfileKeyValueId
                    },
                    new ProfileKeyValue
                    {
                        Key = "AutoJoin",
                        Value = AutoJoin.ToString(),
                        ProfileId = profile.ProfileId,
                        ProfileKeyValueId = existingProfile.Data.First(x => x.Key == "AutoJoin").ProfileKeyValueId
                    },
                    new ProfileKeyValue
                    {
                        Key = "HiddenNetwork",
                        Value = HiddenNetwork.ToString(),
                        ProfileId = profile.ProfileId,
                        ProfileKeyValueId = existingProfile.Data.First(x => x.Key == "HiddenNetwork").ProfileKeyValueId
                    },
                    new ProfileKeyValue
                    {
                        Key = "SecurityType",
                        Value = SecurityType.ToString(),
                        ProfileId = profile.ProfileId,
                        ProfileKeyValueId = existingProfile.Data.First(x => x.Key == "SecurityType").ProfileKeyValueId
                    },
                    new ProfileKeyValue
                    {
                        Key = "Password",
                        Value = Password,
                        ProfileId = profile.ProfileId,
                        ProfileKeyValueId = existingProfile.Data.First(x => x.Key == "Password").ProfileKeyValueId
                    },
                };
            }
            else
            {
                profile.Data = new List<ProfileKeyValue>
                {
                    new ProfileKeyValue
                    {
                        Key = "ServiceSetIdentifier",
                        Value = ServiceSetIdentifier
                    },
                    new ProfileKeyValue
                    {
                        Key = "AutoJoin",
                        Value = AutoJoin.ToString()
                    },
                    new ProfileKeyValue
                    {
                        Key = "HiddenNetwork",
                        Value = HiddenNetwork.ToString()
                    },
                    new ProfileKeyValue
                    {
                        Key = "SecurityType",
                        Value = SecurityType.ToString()
                    },
                    new ProfileKeyValue
                    {
                        Key = "Password",
                        Value = Password
                    },
                };
            }

            return profile;
        }

        public BaseProfileModel ToModel(CheckIn.Data.Entities.Profile wifiProfile)
        {
            if (wifiProfile != null)
            {
                ProfileId = wifiProfile.ProfileId;
                ChannelId = wifiProfile.ChannelId;
                ServiceSetIdentifier = wifiProfile.Data.First(x => x.Key == "ServiceSetIdentifier").Value;
                AutoJoin = Convert.ToBoolean(wifiProfile.Data.First(x => x.Key == "AutoJoin").Value);
                HiddenNetwork = Convert.ToBoolean(wifiProfile.Data.First(x => x.Key == "HiddenNetwork").Value);
                SecurityType = Convert.ToInt16(wifiProfile.Data.First(x => x.Key == "SecurityType").Value);
                Password = wifiProfile.Data.First(x => x.Key == "Password").Value;
            }
            return this;
        }
    }
}