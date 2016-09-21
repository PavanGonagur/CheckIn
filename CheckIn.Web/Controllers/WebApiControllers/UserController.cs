namespace CheckIn.Web.Controllers.WebApiControllers
{
    using System;
    using System.IO;
    using System.Web.Mvc;

    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.BusinessImpl;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    using Newtonsoft.Json;

    public class UserController : Controller
    {
        private readonly IUserBusiness userBusiness;

        public UserController()
        {
            this.userBusiness = new UserBusiness();
        }

        [HttpGet]
        [Route("RetrieveUser")]
        public string RetrieveUser(int id)
        {
            try
            {
                return this.userBusiness.RetrieveUser(id);
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public string AddUser()
        {
            try
            {
                Stream req = this.Request.InputStream;
                req.Seek(0, SeekOrigin.Begin);
                string json = new StreamReader(req).ReadToEnd();
                var user = JsonConvert.DeserializeObject<UserModel>(json);
                
                return this.userBusiness.AddUser(user).ToString();
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        //[HttpGet]
        //public string TestApi()
        //{
        //    try
        //    {
        //        EmailGateway.SendMail(new EmailModel());
        //        return "success";
        //    }
        //    catch (Exception)
        //    {
        //        return "fail";
        //    }
        //}
    }
}