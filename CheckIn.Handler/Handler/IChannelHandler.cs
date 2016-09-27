using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data;
    using CheckIn.Data.Entities;

    public interface IChannelHandler
    {
        void DeleteChannel(Channel channel);

        List<Channel> RetrieveAllChannels();

        void UpdateChannel(Channel channel);

        Channel RetrieveChannel(int channelId);

        int AddChannel(Channel channel);

        User RetrieveUserOnEmail(string email);

        List<Channel> RetrieveChannelsOnAdmin(int adminId);

        Channel GetChannelOnText(string searchText);

        List<Channel> RetrieveChannelsByLocationAndUser(float latitude, float longitude, int userId);
    }
}
