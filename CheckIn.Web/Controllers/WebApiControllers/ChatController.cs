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

    public class ChatController : ApiController
    {
        private readonly IChatBusiness chatBusiness;

        public ChatController()
        {
            this.chatBusiness = new ChatBusiness();
        }

        [HttpPost]
        [Route("AddChatMessage")]
        public async Task<string> AddChatMessage()
        {
            try
            {
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var chatMessage = JsonConvert.DeserializeObject<ChatMessageModel>(stream);

                this.chatBusiness.AddChatMessage(chatMessage);
              
                status = new Status() { Code = 0, Message = "Message sent" };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });

            }
            catch (Exception ex)
            {
                var status = new Status() { Code = 1, Message = ex.Message };
                return JsonConvert.SerializeObject(new ResponseMessage() { Status = status });
            }
        }

        [HttpPost]
        [Route("AddChatRoom")]
        public async Task<string> AddChatRoom()
        {
            try
            {
                Status status;
                var stream = await this.Request.Content.ReadAsStringAsync();
                var chatMessage = JsonConvert.DeserializeObject<ChatMessageModel>(stream);

                this.chatBusiness.AddChatMessage(chatMessage);

                status = new Status() { Code = 0, Message = "Message sent" };
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
