using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IUserHandler
    {
        int AddUser(User user);

        int CheckUserExists(string email);

        User RetrieveUser(int userId);

        void UpdateUser(User user);

        List<User> RetrieveAllUsers();

        void DeleteUser(User user);

        User RetrieveUserOnEmail(string emailId);
    }
}
