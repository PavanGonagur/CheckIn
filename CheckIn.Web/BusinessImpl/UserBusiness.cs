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
    using CheckIn.Web.Models;

    using Newtonsoft.Json;

    public class UserBusiness:IUserBusiness
    {
        private IUserHandler userHandler;

        public UserBusiness()
        {
            this.userHandler = new UserHandler();
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
            var userEntity = new User
                                 {
                                     Email = user.Email,
                                     Name = user.Name,
                                     PhoneNumber = user.PhoneNumber,
                                     ProfilePhoteUrl = user.ProfilePhotoUrl,
                                     UserPhoto = user.UserPhoto,
                                     FirstName = user.FirstName,
                                     LastName = user.LastName
                                 };

            return this.userHandler.AddUser(userEntity);
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
    }
}