using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IAdminHandler
    {
        int AddAdmin(Admin admin);

        void UpdateAdmin(Admin admin);

        Admin RetrieveAdmin(int adminId);

        Admin RetrieveAdminOnEmail(string email);
    }
}
