using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models
{
    using Newtonsoft.Json;

    public class AdminModel
    {
        [JsonProperty("adminId")]
        public int AdminId { get; set; }

        public int Channels { get; set; }

        public bool IsSuperAdmin { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profilePhoteUrl")]
        public string ProfilePhoteUrl { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public string Validate()
        {
            return null;
        }

        public AdminModel ToModel(CheckIn.Data.Entities.Admin admin)
        {
            AdminId = admin.AdminId;
            Email = admin.Email;
            Name = admin.Name;
            PhoneNumber = admin.PhoneNumber;
            Channels = admin.AdminChannelMaps.Count;
            IsSuperAdmin = admin.IsSuperAdmin;
            return this;
        }

        public CheckIn.Data.Entities.Admin ToEntity()
        {
            return new CheckIn.Data.Entities.Admin
            {
                AdminId = AdminId,
                Email = Email,
                Name = Name,
                IsSuperAdmin = IsSuperAdmin,
                Password = Password,
                PhoneNumber = PhoneNumber,
                ProfilePhoteUrl = ProfilePhoteUrl
            };
        }
    }
}