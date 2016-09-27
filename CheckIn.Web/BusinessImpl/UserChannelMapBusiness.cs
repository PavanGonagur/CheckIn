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
    using CheckIn.Web.Models.Channel;
    using CheckIn.Web.Utilities;

    using WebGrease.Css.Extensions;

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
            var hashedOtp = HashUtility.GetHash(registerToChannelModel.Otp.Token);
            var userChannelMap = new UserChannelMap()
                                                {
                                                    UserId = registerToChannelModel.Otp.CheckInServerUserId,
                                                    Otp = hashedOtp,
                                                    ChannelId = registerToChannelModel.Otp.ChannelId
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
                                               CoordinatesModel = new CoordinatesModel()
                                                                      {
                                                   Latitude = channel.Latitude,
                                                   Longitude = channel.Longitude
                                               },
                                               
                                               Resources = new ResourceModel()
                                                               {
                                                   Profiles = channel.Profiles.Select(x => new ProfileModel(x)).ToList(),
                                                   Applications = channel.Applications.Select(x => new ApplicationModel(x)).ToList(),
                                                   ChatRooms = channel.ChatRooms.Select(x => new ChatRoomModel(x)).ToList(),
                                                   Contacts = channel.Contacts.Select(x => new ContactModel(x)).ToList(),
                                                   WebClips = channel.WebClips.Select(x => new WebClipModel(x)).ToList(),
                                                   Locations = channel.Locations.Select(x => new LocationModel(x)).ToList()
                                               }
                                              
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
                var emailUserName = EmailUtility.GetFormattedEmailUserName(email.Split('@')[0]);
                var user = this.userHandler.RetrieveUserOnEmailUserName(emailUserName);
                if (user != null)
                {
                    this.userChannelMapHelper.AddUserChannelMap(user, channel,email);
                }
                else
                {
                    unRegisteredEmails.Add(email);
                    var userEmailEntity = new UserEmailChannel()
                                              {
                                                  ChannelId = userChannelMapModel.ChannelId,
                                                  Email = email,
                                                  EmailUserName = emailUserName
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
                var userChannelMap =
                this.userChannelMapHandler.RetrieveUserChannelMapOnUserChannel(
                    resendOtpModel.CheckInServerUserId,
                    resendOtpModel.ChannelId);
                this.userChannelMapHelper.AddUserChannelMap(user,channel, userChannelMap.EmailId);
            }
        }
    }
}