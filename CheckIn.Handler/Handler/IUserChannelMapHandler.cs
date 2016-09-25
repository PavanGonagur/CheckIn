using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IUserChannelMapHandler
    {
        UserChannelMap RegisterToChannel(UserChannelMap userChannelMap);

        void AddUserChannelMap(UserChannelMap userChannelMap);


        UserChannelMap RetrieveUserChannelMapOnUserChannel(int userId, int channelId);
    }
}
