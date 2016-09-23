using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Controllers.WebApiControllers
{
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Http;

    using CheckIn.Web.Business;
    using CheckIn.Web.BusinessImpl;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    using Newtonsoft.Json;

    public class AdminController : ApiController
    {
        private readonly IAdminBusiness adminBusiness;

        private readonly IAuthenticationBusiness authenticationBusiness;
        
        public AdminController()
        {
            this.adminBusiness = new AdminBusiness();
            this.authenticationBusiness = new AuthenticationBusiness();
        }

        [HttpPost]
        [Route("AddAdmin")]
        public async Task<string> AddAdmin()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var admin = JsonConvert.DeserializeObject<AdminModel>(stream);
                return this.adminBusiness.AddAdmin(admin).ToString();
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpPost]
        [Route("AuthenticateAdmin")]
        public async Task<string> AuthenticateAdmin()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var admin = JsonConvert.DeserializeObject<AuthenticateAdminModel>(stream);
                return this.authenticationBusiness.CheckPasswordHashMatches(admin) ? "Success" : "Failure";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpGet]
        [Route("RetrieveAdmin")]
        public string RetrieveAdmin(int id)
        {
            try
            {
                var admin = this.adminBusiness.RetrieveAdmin(id);
                if (admin != null)
                {
                    var data = new Data() { JsonDataResponse = JsonConvert.SerializeObject(admin) };
                    var status = new Status() { Code = 0, Message = "Got Admin" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = data, Status = status });
                }
                return "Admin Not Found";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpGet]
        [Route("RetrieveAllAdmins")]
        public string RetrieveAllAdmins()
        {
            try
            {
                var admins = this.adminBusiness.RetrieveAllAdmins();
                if (admins != null)
                {
                    return admins;
                }
                return "No Admins Found";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }
    }
}