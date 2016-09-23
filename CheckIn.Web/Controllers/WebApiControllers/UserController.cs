namespace CheckIn.Web.Controllers.WebApiControllers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;

    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.BusinessImpl;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    using Newtonsoft.Json;

    public class UserController : ApiController
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
                var user = this.userBusiness.RetrieveUser(id);
                if (user != null)
                {
                    return user;
                }

                return "User Not Found";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<string> AddUser()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserModel>(stream);
                
                var userId = this.userBusiness.AddUser(user).ToString();

                var data = new Data() { JsonDataResponse = JsonConvert.SerializeObject(userId) };
                var status = new Status() { Code = 0, Message = "Added User" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Data = data, Status = status });

            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpGet]
        [Route("RetrieveAllUsers")]
        public string RetrieveAllUsers()
        {
            try
            {
                var users = this.userBusiness.RetrieveAllUsers();
                if (users != null)
                {
                    return users;
                }
                return "No Users Found";
            }
            catch (Exception ex)
            {
                return "Error Occured " + ex;
            }
        }

        [HttpPost]
        [Route("RetrieveAllUsers")]
        public async Task<string> UpdateUserRegistrationId()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UpdateUserRegistrationModel>(stream);

                this.userBusiness.UpdateUserRegistrationId(user);
                var status = new Status() { Code = 0, Message = "Updated User RegistrationId" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpGet]
        public string TestApi()
        {
            try
            {
                //EmailGateway.SendMail(new EmailModel());
                //SMSGateway.SendSms("Hello sede","9738131081");
                //return OTPUtility.GenerateOTP();
                return "success";
            }
            catch (Exception)
            {
                return "fail";
            }
        }
    }
}