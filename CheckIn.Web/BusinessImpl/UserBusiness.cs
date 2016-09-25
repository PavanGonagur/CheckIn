using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Helpers;
    using CheckIn.Web.Models;

    using Newtonsoft.Json;

    public class UserBusiness:IUserBusiness
    {
        private readonly IUserHandler userHandler;

        private readonly IUserEmailChannelHandler userEmailChannelHandler;

        private readonly IUserChannelMapHelper userChannelMapHelper;

        private readonly IChannelHandler channelHandler;

        public UserBusiness()
        {
            this.userHandler = new UserHandler();
            this.userEmailChannelHandler = new UserEmailChannelHandler();
            this.userChannelMapHelper = new UserChannelMapHelper();
            this.channelHandler = new ChannelHandler();
        }
        public string RetrieveUser(int userId)
        {
            var user = this.userHandler.RetrieveUser(userId);
            if (user != null)
            {
                return JsonConvert.SerializeObject(user);
            }
            return null;
        }

        public int AddUser(UserModel user)
        {
            var exsitingUserId = this.userHandler.CheckUserExists(user.Email);
            if (exsitingUserId != 0)
            {
                return exsitingUserId;
            }
            var userEntity = new User
                                 {
                                     Email = user.Email,
                                     Name = user.Name,
                                     PhoneNumber = user.PhoneNumber,
                                     ProfilePhoteUrl = user.ProfilePhotoUrl,
                                     UserPhoto = user.UserPhoto,
                                     FirstName = user.FirstName,
                                     LastName = user.LastName,
                                     EmailUserName = user.Email.Split('@')[0]
            };
            var userId = this.userHandler.AddUser(userEntity);
            if (userId > 0)
            {
                var userEmailChannelList = this.userEmailChannelHandler.RetrieveUserEmailChannelOnUserEmail(user.Email.Split('@')[0]);
                if (userEmailChannelList != null)
                {
                    foreach (var userEmailChannel in userEmailChannelList)
                    {
                        var channel = this.channelHandler.RetrieveChannel(userEmailChannel.ChannelId);
                        this.userChannelMapHelper.AddUserChannelMap(userEntity, channel);
                        this.userEmailChannelHandler.DeleteUserEmailChannel(userEmailChannel);
                    }
                }
            }
            return userId;
        }

        public string RetrieveAllUsers()
        {
            var users = this.userHandler.RetrieveAllUsers();
            if (users != null)
            {
                return JsonConvert.SerializeObject(users);
            }
            return null;
        }

        public void UpdateUserRegistrationId(UpdateUserRegistrationModel updateUserRegistrationModel)
        {
            var user = this.userHandler.RetrieveUser(updateUserRegistrationModel.CheckInServerUserId);
            user.RegistrationId = updateUserRegistrationModel.RegistrationId;
            this.userHandler.UpdateUser(user);
        }

        public void UpdateUserPhoneNumber(AddPhoneNumberModel addPhoneNumberModel)
        {
            var user = this.userHandler.RetrieveUser(addPhoneNumberModel.CheckInServerUserId);
            user.PhoneNumber = addPhoneNumberModel.PhoneNumber;
            this.userHandler.UpdateUser(user);
        }
    }
}