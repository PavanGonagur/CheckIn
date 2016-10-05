using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckIn.Web.Models.Channel;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models;
    using CheckIn.Web.Models.User;

    public interface IUserBusiness
    {
        string RetrieveUser(int userId);

        int AddUser(UserModel user);

        string RetrieveAllUsers();

        void UpdateUserRegistrationId(UpdateUserRegistrationModel updateUserRegistrationModel);

        void UpdateUserPhoneNumber(AddPhoneNumberModel addPhoneNumberModel);

        List<ChannelUser> RetrieveUsersByChannel(int channelId);

        User RetrieveUserOnEmail(string email);

        void UnassignUserForChannel(User user, int channelId);

        void DeleteUserEmailChannel(string email, int channelId);
    }
}
