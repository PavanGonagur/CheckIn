using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Web.Models;
    using CheckIn.Web.Models.Channel;

    public interface IChannelBusiness
    {
        int AddChannel(ChannelModel channelModel);

        ChannelListModel RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId);
    }
}
