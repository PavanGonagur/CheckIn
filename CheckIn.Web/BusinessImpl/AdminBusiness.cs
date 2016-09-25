using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    using Newtonsoft.Json;

    public class AdminBusiness : IAdminBusiness
    {
        private IAdminHandler adminHandler;

        public AdminBusiness()
        {
            this.adminHandler = new AdminHandler();
        }
        public Admin RetrieveAdmin(int id)
        {
            var admin = this.adminHandler.RetrieveAdmin(id);
            
            return admin;
        }

        public int AddAdmin(AdminModel admin)
        {
            var userEntity = new Admin
            {
                Email = admin.Email,
                Name = admin.Name,
                PhoneNumber = admin.PhoneNumber,
                ProfilePhoteUrl = admin.ProfilePhoteUrl,
                Password = HashUtility.GetHash(admin.Password)
            };

            return this.adminHandler.AddAdmin(userEntity);
        }

        public Admin RetrieveAdminOnEmail(string email)
        {
            return this.adminHandler.RetrieveAdminOnEmail(email);
        }

        public string RetrieveAllAdmins()
        {
            var admins = this.adminHandler.RetrieveAllAdmins();
            if (admins != null)
            {
                return JsonConvert.SerializeObject(admins);
            }
            return null;
        }
    }
}