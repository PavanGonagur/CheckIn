using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckIn.Web.Controllers.WebApiControllers
{
    using System.IO;

    using CheckIn.Web.Business;
    using CheckIn.Web.BusinessImpl;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    using Newtonsoft.Json;

    public class AdminController : Controller
    {
        private readonly IAdminBusiness adminBusiness;
        
        public AdminController()
        {
            this.adminBusiness = new AdminBusiness();
        }

        [HttpPost]
        [Route("AddAdmin")]
        public string AddAdmin()
        {
            try
            {
                Stream req = this.Request.InputStream;
                req.Seek(0, SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                var admin = JsonConvert.DeserializeObject<AdminModel>(json);
                return this.adminBusiness.AddAdmin(admin).ToString();
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        //[HttpPost]
        //[Route("AuthenticateAdmin")]
        //public string AuthenticateAdmin()
        //{
        //    try
        //    {
        //        Stream req = this.Request.InputStream;
        //        req.Seek(0, SeekOrigin.Begin);
        //        string json = new StreamReader(req).ReadToEnd();
        //        var admin = JsonConvert.DeserializeObject<AuthenticateAdminModel>(json);
        //        //Todo: call authenticate utility
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Error Occured " + ex;
        //    }
        //}
    }
}