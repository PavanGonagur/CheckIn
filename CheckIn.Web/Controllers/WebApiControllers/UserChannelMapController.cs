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
                var channel = this.channelBusiness.RegisterToChannel(registerToChannel.OTP);
                if (channel != null)
                {
                    var data = new Data() { JsonDataResponse = JsonConvert.SerializeObject(channel) };
                    status = new Status() { Code = 0, Message = "Authentication successful, Got Channel details" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Data = data, Status = status });
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
        [Route("AddUserChannelMap")]
        public async Task<string> AddUserChannelMap()
        {
            try
            {
                var stream = await this.Request.Content.ReadAsStringAsync();
                var userChannelMapModel = JsonConvert.DeserializeObject<UserChannelMapModel>(stream);
                Status status;
                //var channel = this.channelBusiness.RegisterToChannel(userChannelMapModel);
                //if (channel != null)
                //{
                //    var data = new Data() { JsonDataResponse = JsonConvert.SerializeObject(channel) };
                //    status = new Status() { Code = 0, Message = "Authentication successful, Got Channel details" };
                //    return JsonConvert.SerializeObject(new ResponseMessage() { Data = data, Status = status });
                //}
                status = new Status() { Code = 1, Message = "Authentication failed" };
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
