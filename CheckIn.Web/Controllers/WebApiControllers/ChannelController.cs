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
    }
}
