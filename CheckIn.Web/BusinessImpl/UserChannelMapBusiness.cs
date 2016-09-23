using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using System.Threading.Tasks;

    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Common;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    public class UserChannelMapBusiness : IUserChannelMapBusiness
    {
        private readonly IUserChannelMapHandler userChannelMapHandler;

        private readonly IChannelHandler channelHandler;

        private readonly IUserHandler userHandler;

        private readonly IUserEmailChannelHandler userEmailChannelHandler;

        public UserChannelMapBusiness()
        {
            this.userChannelMapHandler = new UserChannelMapHandler();
            this.channelHandler = new ChannelHandler();
            this.userHandler = new UserHandler();
            this.userEmailChannelHandler = new UserEmailChannelHandler();
        }
        public Channel RegisterToChannel(string otp)
        {
            var hashedOtp = HashUtility.GetHash(otp);
            var userMapChannel = this.userChannelMapHandler.RegisterToChannel(hashedOtp);
            if (userMapChannel != null)
            {
                return this.channelHandler.RetrieveChannel(userMapChannel.ChannelId);
            }
            return null;
        }

        public void AddUserChannelMap(UserChannelMapModel userChannelMapModel)
        {
            var unRegisteredEmails = new List<string>();
            foreach (var email in userChannelMapModel.Emails)
            {
                var user = this.userHandler.RetrieveUserOnEmail(email);
                if (user != null)
                {
                    var userChannelEntity = new UserChannelMap()
                    {
                        UserId = user.UserId,
                        ChannelId = userChannelMapModel.ChannelId
                    };
                    this.userChannelMapHandler.AddUserChannelMap(userChannelEntity);
                }
                else
                {
                    unRegisteredEmails.Add(email);
                    var userEmailEntity = new UserEmailChannel()
                                              {
                                                  ChannelId = userChannelMapModel.ChannelId,
                                                  Email = email,
                                                  EmailUserName = email.Split('@')[0]
                                              };
                    this.userEmailChannelHandler.AddUserEmailChannel(userEmailEntity);
                }
            }
            Parallel.ForEach(unRegisteredEmails, x => this.SendMail(x, userChannelMapModel.ChannelId));
        }

        private void SendMail(string email,int channelId)
        {
            var channel = this.channelHandler.RetrieveChannel(channelId);
            EmailGateway.SendMail(
                new EmailModel()
                    {
                        To = email,
                        Subject = string.Format(Constants.UserRegisterSubject, channel.Name),
                        Body = string.Format(Constants.UserRegisterBody, channel.Name)
                    });
        }
    }
}