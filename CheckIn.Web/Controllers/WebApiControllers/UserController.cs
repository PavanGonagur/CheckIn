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
                Status status;
                if (user != null)
                {
                    status = new Status() { Code = 0, Message = "Got User" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = user, Status = status });
                }

                status = new Status() { Code = 1, Message = "User Not Found" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<string> AddUser()
        {
            try
            {
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<UserModel>(stream);
                
                var userId = this.userBusiness.AddUser(user).ToString();
                if (userId.Equals("0"))
                {
                    status = new Status() { Code = 1, Message = "Failed to add user" };
                    return JsonConvert.SerializeObject(new ResponseMessage() {Status = status });
                }

                var addUserResponse = new AddUserResponse() {UserId = userId};
                status = new Status() { Code = 0, Message = "Added User" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Data = addUserResponse, Status = status });

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
                Status status;
                var users = this.userBusiness.RetrieveAllUsers();
                if (users != null)
                {
                    status = new Status() { Code = 0, Message = "Got Users" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = users, Status = status });
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

        [HttpPost]
        [Route("AddPhoneNumber")]

        public async Task<string> AddPhoneNumber()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<AddPhoneNumberModel>(stream);

                this.userBusiness.UpdateUserPhoneNumber(user);
                var status = new Status() { Code = 0, Message = "Updated User PhoneNumber" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        //[HttpPost]
        //public async Task<string> TestApi()
        //{
        //    try
        //    {
        //        Status status;
        //        var stream = await this.Request.Content.ReadAsStringAsync();
        //        var user = JsonConvert.DeserializeObject<UserModel>(stream);

        //        var userId = this.userBusiness.AddUser(user).ToString();
        //        if (userId.Equals("0"))
        //        {
        //            status = new Status() { Code = 1, Message = "Failed to add user" };
        //            return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
        //        }

        //        var addUserResponse = new AddUserResponse() { UserId = userId };
        //        status = new Status() { Code = 0, Message = "Added User" };
        //        var test = JsonConvert.SerializeObject(new ResponseMessage() { Data = addUserResponse, Status = status });
        //        var b = test.Replace("\\","");
        //        var revert = JsonConvert.DeserializeObject<ResponseMessage>(b);

        //        //EmailGateway.SendMail(new EmailModel());
        //        //SMSGateway.SendSms("Hello sede","9738131081");
        //        //return OTPUtility.GenerateOTP();
        //        return "success";
        //    }
        //    catch (Exception)
        //    {
        //        return "fail";
        //    }
        //}
    }
}