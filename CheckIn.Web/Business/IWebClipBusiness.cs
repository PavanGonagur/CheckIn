using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;

    public interface IWebClipBusiness
    {
        int AddWebClip(WebClip webClip);

        void DeleteWebClip(WebClip webClip);

        WebClip RetrieveWebClipById(int webClipId);
    }
}
