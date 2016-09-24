using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IUserEmailChannelHandler
    {
        void AddUserEmailChannel(UserEmailChannel userEmailChannel);

        List<UserEmailChannel> RetrieveUserEmailChannelOnUserEmail(string userEmail);

        void DeleteUserEmailChannel(UserEmailChannel userEmail);
    }
}
