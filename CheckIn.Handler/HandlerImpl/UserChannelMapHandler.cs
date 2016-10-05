using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using System.Data.Entity.Migrations;

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
        public UserChannelMap RegisterToChannel(UserChannelMap userChannelMap)
        {
            var query = this.checkInDb.UserChannelMaps.Where(x => x.Otp == userChannelMap.Otp && x.UserId == userChannelMap.UserId && x.ChannelId == userChannelMap.ChannelId);
            if (query.Any())
            {
                var currentChannel = query.FirstOrDefault();
                if (currentChannel != null)
                {
                    //Once otp authentication is successful set otp to null
                    userChannelMap.ChannelId = currentChannel.ChannelId;
                    userChannelMap.Otp = null;
                    userChannelMap.EmailId = currentChannel.EmailId;
                    this.AddUserChannelMap(userChannelMap);
                    return currentChannel;
                }
            }
            return null;
        }

        public void AddUserChannelMap(UserChannelMap userChannelMap)
        {
            this.checkInDb.UserChannelMaps.AddOrUpdate(userChannelMap);
            this.checkInDb.SaveChanges();
        }

        public List<UserChannelMap> RetrieveUserChannelMapByChannelId(int channelId)
        {
            var query = this.checkInDb.UserChannelMaps.Where(x => x.ChannelId == channelId);
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public UserChannelMap RetrieveUserChannelMapOnUserChannel(int userId, int channelId)
        {
            var query = this.checkInDb.UserChannelMaps.Where(x => x.ChannelId == channelId && x.UserId == userId);
            if (query.Any())
            {
                var current = query.FirstOrDefault();
                if (current != null)
                {
                    return current;
                }
            }
            return null;
        }

        public void DeleteUserChannelMap(UserChannelMap userChannelMap)
        {
           
           this.checkInDb.UserChannelMaps.Remove(userChannelMap);
           this.checkInDb.SaveChanges();
        }
    }
}
