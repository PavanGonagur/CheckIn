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
    using CheckIn.Web.Helpers;
    using CheckIn.Web.Models;
    using CheckIn.Web.Utilities;

    public class UserChannelMapBusiness : IUserChannelMapBusiness
    {
        private readonly IUserChannelMapHandler userChannelMapHandler;

        private readonly IChannelHandler channelHandler;

        private readonly IUserHandler userHandler;

        private readonly IUserEmailChannelHandler userEmailChannelHandler;

        private readonly IUserChannelMapHelper userChannelMapHelper;

        public UserChannelMapBusiness()
        {
            this.userChannelMapHandler = new UserChannelMapHandler();
            this.channelHandler = new ChannelHandler();
            this.userHandler = new UserHandler();
            this.userEmailChannelHandler = new UserEmailChannelHandler();
            this.userChannelMapHelper = new UserChannelMapHelper();
        }
        public RegisterToChannelResponseModel RegisterToChannel(RegisterToChannelModel registerToChannelModel)
        {
            var hashedOtp = HashUtility.GetHash(registerToChannelModel.OTP);
            var userChannelMap = new UserChannelMap()
                                                {
                                                    UserId = registerToChannelModel.CheckInServerUserId,
                                                    Otp = hashedOtp
                                                };
            var userMapChannel = this.userChannelMapHandler.RegisterToChannel(userChannelMap);
            if (userMapChannel != null)
            {
                var channel = this.channelHandler.RetrieveChannel(userMapChannel.ChannelId);
                var registerToChannel = new RegisterToChannelResponseModel()
                                            {
                                               Name = channel.Name,
                                               ChannelId = channel.ChannelId,
                                               IsLocationBased = channel.IsLocationBased,
                                               IsPublic = channel.IsPublic,
                                               Latitude = channel.Latitude,
                                               Longitude = channel.Longitude
                                            };
                return registerToChannel;
            }
            return null;
        }

        public void AddUserChannelMap(UserChannelMapModel userChannelMapModel)
        {
            var unRegisteredEmails = new List<string>();
            var channel = this.channelHandler.RetrieveChannel(userChannelMapModel.ChannelId);
            foreach (var email in userChannelMapModel.Emails)
            {
                var user = this.userHandler.RetrieveUserOnEmail(email);
                if (user != null)
                {
                    this.userChannelMapHelper.AddUserChannelMap(user, channel);
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
            Parallel.ForEach(unRegisteredEmails, x => this.userChannelMapHelper.SendMail(channel,x, Constants.UserRegisterBody, Constants.UserRegisterSubject));
        }

        public void ResendOtp(ResendOtpModel resendOtpModel)
        {
            var user = this.userHandler.RetrieveUser(resendOtpModel.CheckInServerUserId);
            var channel = this.channelHandler.RetrieveChannel(resendOtpModel.ChannelId);
            if (user != null && channel != null)
            {
                this.userChannelMapHelper.AddUserChannelMap(user,channel);
            }
        }
    }
}