using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckIn.Web.Controllers.WebApiControllers
{
    using System.Threading.Tasks;

    using CheckIn.Web.Business;
    using CheckIn.Web.BusinessImpl;
    using CheckIn.Web.Models;
    using CheckIn.Web.Models.Channel;

    using Newtonsoft.Json;

    public class UserChannelMapController : ApiController
    {
        private IUserChannelMapBusiness channelBusiness;
        public UserChannelMapController()
        {
            this.channelBusiness = new UserChannelMapBusiness();
        }

        [HttpPost]
        [Route("RegisterToChannel")]
        public async Task<string> RegisterToChannel()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var registerToChannel = JsonConvert.DeserializeObject<RegisterToChannelModel>(stream);
                Status status;
                var channel = this.channelBusiness.RegisterToChannel(registerToChannel);
                if (channel != null)
                {
                    status = new Status() { Code = 0, Message = "Authentication successful, Got Channel details" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = channel, Status = status });
                }
                status = new Status() { Code = 1, Message = "Authentication failed" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpPost]
        [Route("GetPublicChannel")]
        public async Task<string> GetPublicChannel()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var registerToChannel = JsonConvert.DeserializeObject<GetPublicChannelModel>(stream);
                Status status;
                var channel = this.channelBusiness.GetPublicChannel(registerToChannel);
                if (channel != null)
                {
                    status = new Status() { Code = 0, Message = "Got Channel details" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = channel, Status = status });
                }
                status = new Status() { Code = 1, Message = "No channel found" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpPost]
        [Route("AddUserChannelMap")]
        public async Task<string> AddUserChannelMap()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var userChannelMapModel = JsonConvert.DeserializeObject<UserChannelMapModel>(stream);
                Status status;
                this.channelBusiness.AddUserChannelMap(userChannelMapModel);
                status = new Status() { Code = 0, Message = "Users Added" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpPost]
        [Route("ResendOtp")]

        public async Task<string> ResendOtp()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var userChannelMapModel = JsonConvert.DeserializeObject<ResendOtpModel>(stream);
                Status status;
                this.channelBusiness.ResendOtp(userChannelMapModel);
                status = new Status() { Code = 0, Message = "Resend Otp successful" };
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
