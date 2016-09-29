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
    using CheckIn.Web.Common;
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
         
        public int Save(AdminModel model)
        {
            var adminEntity = model.ToEntity();
            if (model.AdminId > 0)
            {
                this.adminHandler.UpdateAdmin(adminEntity);
                return model.AdminId;
            }
            EmailGateway.SendMail(new EmailModel()
                                      {
                                          Body = string.Format(Constants.AdminPasswordBody,adminEntity.Name,adminEntity.Password,Constants.ServerUrl),
                                          Subject = Constants.AdminPasswordSubject,
                                          To = adminEntity.Email
                                      });
            return this.adminHandler.AddAdmin(adminEntity);
        }

        public Admin RetrieveAdminOnEmail(string email)
        {
            return this.adminHandler.RetrieveAdminOnEmail(email);
        }

        public List<Admin> RetrieveAllAdmins()
        {
            return this.adminHandler.RetrieveAllAdmins();
        }
    }
}