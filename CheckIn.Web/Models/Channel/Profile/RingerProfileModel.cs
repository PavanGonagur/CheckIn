using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using CheckIn.Data;
using CheckIn.Data.Entities;
using CheckIn.Web.BusinessImpl;

namespace CheckIn.Web.Models.Channel.Profile
{
    public class RingerProfileModel : BaseProfileModel
    {
        public RingerProfileModel()
        {

        }

        public RingerProfileModel(int id, ProfileType profileType)
        {
            ChannelId = id;
            ProfileType = profileType;
        }

        [DisplayName("Set Device On")]
        public int SoundSetting { get; set; }

        public Dictionary<int, string> SoundSettingValues()
        {
            Dictionary<int, string> soundSettingDropDown = new Dictionary<int, string>
            {
                { 0, "Silent" },
                { 1, "Vibrate" },
                { 2, "Ring" },
                { 3, "Ring and Vibrate" }
            };
            return soundSettingDropDown;
        }

        public override CheckIn.Data.Entities.Profile ToEntity()
        {
            var profile = new CheckIn.Data.Entities.Profile
            {
                ProfileId = ProfileId,
                ChannelId = ChannelId,
                Type = ProfileType.Silent,
                Data = new List<ProfileKeyValue>
                {
                    new ProfileKeyValue
                    {
                        Key = "SoundSetting",
                        Value = SoundSetting.ToString()
                    }
                }
            };

            return profile;
        }

        public BaseProfileModel ToModel(CheckIn.Data.Entities.Profile ringerProfile)
        {
            if (ringerProfile != null)
            {
                ProfileId = ringerProfile.ProfileId;
                ChannelId = ringerProfile.ChannelId;
                SoundSetting = Convert.ToInt16(ringerProfile.Data.First(x => x.Key == "SoundSetting").Value);
            }
            return this;
        }
    }
}