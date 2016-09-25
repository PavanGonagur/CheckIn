using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckIn.Data.Entities;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Web.Business;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    public class AuthenticationBusiness:IAuthenticationBusiness
    {
        private IAdminBusiness adminBusiness;
        public AuthenticationBusiness()
        {
            this.adminBusiness = new AdminBusiness();
        }
        public bool CheckPasswordHashMatches(AuthenticateAdminModel authenticateAdminModel)
        {
            try
            {
                var admin = this.adminBusiness.RetrieveAdminOnEmail(authenticateAdminModel.Email);
                var hash = HashUtility.GetHash(authenticateAdminModel.Password);
                return admin.Password.Equals(hash);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Admin AuthenticateUser(string password, string email)
        {
            try
            {
                var admin = this.adminBusiness.RetrieveAdminOnEmail(email);
                //var hash = HashUtility.GetHash(password);
                if (admin != null && admin.Password.Equals(password))
                {
                    return admin;
                }
                return new Admin();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}