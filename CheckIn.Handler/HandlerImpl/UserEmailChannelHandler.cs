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
    public class UserEmailChannelHandler : IUserEmailChannelHandler
    {
        private readonly CheckInDb checkInDb;
        public UserEmailChannelHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public void AddUserEmailChannel(UserEmailChannel userEmailChannel)
        {
            this.checkInDb.UserEmailChannels.Add(userEmailChannel);
            this.checkInDb.SaveChanges();
        }

        public List<UserEmailChannel> RetrieveUserEmailChannelOnUserEmail(string userEmail)
        {
            var query  = this.checkInDb.UserEmailChannels.Where(x => x.EmailUserName.Equals(userEmail));
            if (query.Any())
            {
                return query.ToList();
            }
            return null;
        }

        public void DeleteUserEmailChannel(UserEmailChannel userEmail)
        {
            this.checkInDb.UserEmailChannels.Remove(userEmail);
            this.checkInDb.SaveChanges();
        }
    }
}
