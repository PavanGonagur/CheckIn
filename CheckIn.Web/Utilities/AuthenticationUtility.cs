using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Business;
    using CheckIn.Web.BusinessImpl;

    public class AuthenticationUtility
    {
        private IAdminBusiness adminBusiness;
        public AuthenticationUtility()
        {
            this.adminBusiness = new AdminBusiness();
        }
        public bool CheckPasswordHashMatches(string password, string email)
        {
            try
            {
                var admin = this.adminBusiness.RetrieveAdminOnEmail(email);
                var hash = HashUtility.GetHash(password);
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