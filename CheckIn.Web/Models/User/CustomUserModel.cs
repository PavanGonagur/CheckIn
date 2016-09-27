using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.User
{
    using CheckIn.Handler.CustomEntities;

    public class CustomUserModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string EmailUserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Status { get; set; }

        public CustomUserModel()
        {
            
        }

        public CustomUserModel(CustomUserEntity entity)
        {
            this.Name = entity.Name;
            this.Status = entity.Status;
            this.Email = entity.Email;
            this.EmailUserName = entity.EmailUserName;
            this.FirstName = entity.FirstName;
            this.LastName = entity.LastName;
            this.PhoneNumber = entity.PhoneNumber;
        }

    }
}