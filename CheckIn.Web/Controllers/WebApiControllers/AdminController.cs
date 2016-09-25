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
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var admin = JsonConvert.DeserializeObject<AdminModel>(stream);
                var adminId = this.adminBusiness.AddAdmin(admin).ToString();
                if (adminId.Equals("0"))
                {
                    status = new Status() { Code = 1, Message = "Failed to add user" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
                }
                var addUserResponse = new AddAdminResponse() { AdminId = adminId };
                status = new Status() { Code = 0, Message = "Added User" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Data = addUserResponse, Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
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
                var isAuthenticated = this.authenticationBusiness.CheckPasswordHashMatches(admin);
                var status = new Status() { Code = 0, Message = isAuthenticated ? "Success" : "Failure"};
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpGet]
        [Route("RetrieveAdmin")]
        public string RetrieveAdmin(int id)
        {
            try
            {
                Status status;
                var admin = this.adminBusiness.RetrieveAdmin(id);
                if (admin != null)
                {
                    status = new Status() { Code = 0, Message = "Got Admin" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = admin, Status = status });
                }
                status = new Status() { Code = 1, Message = "Admin not found" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpGet]
        [Route("RetrieveAllAdmins")]
        public string RetrieveAllAdmins()
        {
            try
            {
                Status status;
                var admins = this.adminBusiness.RetrieveAllAdmins();
                if (admins != null)
                {
                    status = new Status() { Code = 0, Message = "Got Users" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = admins, Status = status });
                }
                status = new Status() { Code = 1, Message = "No Users Found" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }
    }
}