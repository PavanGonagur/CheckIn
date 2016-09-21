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
            return JsonConvert.SerializeObject(user);
        }

        public int AddUser(UserModel user)
        {
            var userEntity = new User
                                 {
                                     Email = user.Email,
                                     Name = user.Name,
                                     PhoneNumber = user.PhoneNumber,
                                     ProfilePhoteUrl = user.ProfilePhotoUrl
                                 };

            return this.userHandler.AddUser(userEntity);
        }
    }
}