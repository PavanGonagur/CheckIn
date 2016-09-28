using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models;

    public interface IAdminBusiness
    {
        Admin RetrieveAdmin(int userId);

        int AddAdmin(AdminModel user);

        int Save(AdminModel model);

        Admin RetrieveAdminOnEmail(string email);

        List<Admin> RetrieveAllAdmins();
    }
}
