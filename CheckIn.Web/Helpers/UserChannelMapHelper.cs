using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Helpers
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Common;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    public class UserChannelMapHelper:IUserChannelMapHelper
    {
        private readonly IUserChannelMapHandler userChannelMapHandler;

        public UserChannelMapHelper()
        {
            this.userChannelMapHandler = new UserChannelMapHandler();
        }
        public void AddUserChannelMap(User user, Channel channel,string emailId)
        {
            var otp = OTPUtility.GenerateOTP();
            var userChannelEntity = new UserChannelMap()
            {
                UserId = user.UserId,
                ChannelId = channel.ChannelId,
                Otp = HashUtility.GetHash(otp),
                EmailId = emailId
            };
            this.userChannelMapHandler.AddUserChannelMap(userChannelEntity);
            if (channel.IsLocationBased && !channel.IsPublic)
            {
                this.SendMail(channel, user.Email, Constants.PrivateChannelBody, Constants.PrivateChannelSubject,otp);
            }
            else if (!channel.IsPublic && !channel.IsLocationBased)
            {
                this.SendMail(channel, user.Email, Constants.PrivateChannelNoGeoBasedRestrictionBody, Constants.PrivateChannelSubject, otp);
            }
        }

        public void SendMail(Channel channel, string email, string body, string subject, string otp = null)
        {
            EmailGateway.SendMail(
                new EmailModel()
                {
                    To = email,
                    Subject = string.Format(subject, channel.Name),
                    Body = otp == null ? string.Format(body, channel.Name) : string.Format(body, channel.Name,otp)
                });
        }
    }
}