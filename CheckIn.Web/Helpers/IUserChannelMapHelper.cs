using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Helpers
{
    using CheckIn.Data.Entities;

    public interface IUserChannelMapHelper
    {
        void AddUserChannelMap(User user, Channel channel);

        void SendMail(Channel channel, string email, string body, string subject, string otp = null);
    }
}