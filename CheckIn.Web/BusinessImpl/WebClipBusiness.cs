using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Channel;

    public class WebClipBusiness : IWebClipBusiness
    {
        private readonly IWebClipHandler webClipHandler;

        public WebClipBusiness()
        {
            this.webClipHandler = new WebClipHandler();
        }

        public int AddWebClip(WebClip webClip)
        {
            var exsitingWebClipId = this.webClipHandler.AddOrUpdateWebClip(webClip);
            if (webClip.WebClipId != 0)
            {
                return webClip.WebClipId;
            }
            return exsitingWebClipId;
        }

        public void DeleteWebClip(WebClip webClip)
        {
            this.webClipHandler.DeleteWebClip(webClip);
        }

        //if profile not present returning null
        public WebClip RetrieveWebClipById(int webClipId)
        {
            return this.webClipHandler.RetrieveWebClipById(webClipId);
        }

        public List<WebClipModel> RetrieveWebClipsByChannelId(int channelId)
        {
            var webclips = this.webClipHandler.RetrieveWebClipsByChannelId(channelId);
            if (webclips != null)
            {
                var webclipModelList = webclips.Select(x => new WebClipModel(x)).ToList();
                return webclipModelList;
            }
            return null;
        }
    }
}