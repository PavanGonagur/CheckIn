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

    public class ChannelController : ApiController
    {
        private readonly IChannelBusiness channelBusiness;

        public ChannelController()
        {
            this.channelBusiness = new ChannelBusiness();
        }

        [HttpPost]
        [Route("AddChannel")]
        public async Task<string> AddChannel()
        {
            try
            {
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var channel = JsonConvert.DeserializeObject<ChannelModel>(stream);

                var channelId = this.channelBusiness.AddChannel(channel).ToString();

                if (channelId.Equals("0"))
                {
                    status = new Status() { Code = 1, Message = "Failed to add channel" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
                }
                status = new Status() { Code = 0, Message = "Added Channel" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Data = new AddChannelResponse() {ChannelId = channelId}, Status = status });

            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpPost]
        [Route("RetrieveChannelsByLocationAndUser")]
        public async Task<string> RetrieveChannelsByLocationAndUser()
        {
            try
            {
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<RetireveChannelByLocationAndUserModel>(stream);

                var channels = this.channelBusiness.RetrieveChannelsByLocationAndUser(model.Latitude,model.Longitude,model.UserId);

                if (channels == null)
                {
                    status = new Status() { Code = 1, Message = "No channels found around the area" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
                }
                status = new Status() { Code = 0, Message = "Got channels" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Data = channels, Status = status });

            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpGet]
        [Route("SearchChannel")]
        public async Task<string> GetChannelOnText(string searchText)
        {
            try
            {
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<RetireveChannelByLocationAndUserModel>(stream);

                var channel = this.channelBusiness.GetChannelOnText(searchText);

                if (channel == null)
                {
                    status = new Status() { Code = 1, Message = "No channel found" };
                    return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
                }
                status = new Status() { Code = 0, Message = "Got channel" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Data = channel, Status = status });

            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }
    }
}
