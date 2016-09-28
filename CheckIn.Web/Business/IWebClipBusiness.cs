using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models.Channel;

    public interface IWebClipBusiness
    {
        int AddWebClip(WebClip webClip);

        void DeleteWebClip(WebClip webClip);

        WebClip RetrieveWebClipById(int webClipId);

        List<WebClipModel> RetrieveWebClipsByChannelId(int channelId);
    }
}
