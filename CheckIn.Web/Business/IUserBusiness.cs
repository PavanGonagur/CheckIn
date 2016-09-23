using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Web.Models;

    public interface IUserBusiness
    {
        string RetrieveUser(int userId);

        int AddUser(UserModel user);

        string RetrieveAllUsers();

        void UpdateUserRegistrationId(UpdateUserRegistrationModel updateUserRegistrationModel);
    }
}
