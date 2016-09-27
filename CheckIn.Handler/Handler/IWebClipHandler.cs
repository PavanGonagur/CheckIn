using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IWebClipHandler
    {
        int AddOrUpdateWebClip(WebClip webClip);

        List<WebClip> RetrieveWebClipsByChannelId(int ChannelId);

        WebClip RetrieveWebClipById(int webClipId);

        void DeleteWebClip(WebClip profile);
    }
}
