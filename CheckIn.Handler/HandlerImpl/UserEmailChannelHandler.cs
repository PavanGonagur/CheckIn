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
        public int AddUserEmailChannel(UserEmailChannel userEmailChannel)
        {
            this.checkInDb.UserEmailChannels.Add(userEmailChannel);
            this.checkInDb.SaveChanges();
            var query = from r in this.checkInDb.UserEmailChannels
                        orderby r descending
                        select r;
            if (query.Any())
            {
                return query.First().UserEmailChannelId;
            }
            return 0;
        }
    }
}
