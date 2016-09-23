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
        private readonly IUserChannelMapBusiness channelBusiness;

        public ChannelController()
        {
            this.channelBusiness = new UserChannelMapBusiness();
        }

        //[HttpPost]
        //[Route("AddChannel")]
        //public async Task<string> AddChannel()
        //{
        //    try
        //    {
        //        var stream = await this.Request.Content.ReadAsStringAsync();
        //        var user = JsonConvert.DeserializeObject<UserModel>(stream);

        //        var userId = this.channelBusiness.AddUser(user).ToString();

        //        var data = new Data() { JsonDataResponse = JsonConvert.SerializeObject(userId) };
        //        var status = new Status() { Code = 0, Message = "Added User" };
        //        return JsonConvert.SerializeObject(new ResponseMessage() { Data = data, Status = status });

        //    }
        //    catch (Exception ex)
        //    {
        //        var status = new Status() { Code = 1, Message = ex.Message };
        //        return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
        //    }
        //}
    }
}
