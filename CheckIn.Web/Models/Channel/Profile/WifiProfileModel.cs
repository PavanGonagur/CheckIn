﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CheckIn.Data;
using CheckIn.Data.Entities;

namespace CheckIn.Web.Models.Channel.Profile
{
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

        public CheckIn.Data.Entities.Profile ToEntity()
        {
            return new CheckIn.Data.Entities.Profile
            {
                ProfileId = ProfileId,
                ChannelId = ChannelId,
                Type = ProfileType.WiFi,
                Data = new List<ProfileKeyValue>
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
                }
            };
        }
    }
}