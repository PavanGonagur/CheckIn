using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;

    public class UserChannelMapHandler : IUserChannelMapHandler
    {
        private readonly CheckInDb checkInDb;

        public UserChannelMapHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public UserChannelMap RegisterToChannel(string otp)
        {
            var query = this.checkInDb.UserChannelMaps.Where(x => x.Otp == otp);
            if (query.Any())
            {
                var currentChannel = query.FirstOrDefault();
                if (currentChannel != null)
                {
                    return currentChannel;
                }
            }
            return null;
        }

        public void AddUserChannelMap(UserChannelMap userChannelMap)
        {
            this.checkInDb.UserChannelMaps.Add(userChannelMap);
            this.checkInDb.SaveChanges();
        }
    }
}
