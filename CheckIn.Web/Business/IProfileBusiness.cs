using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;

    public interface IProfileBusiness
    {
        int AddProfile(Profile profile);

        void DeleteProfile(Profile application);

        Profile RetrieveProfileById(int profileId);
    }
}
