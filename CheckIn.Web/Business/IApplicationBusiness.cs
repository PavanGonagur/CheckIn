using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;
    using CheckIn.Web.Models.Channel;

    public interface IApplicationBusiness
    {
        void DeleteApplication(Application application);

        Application RetrieveApplicationById(int applicationId);
        int AddApplication(Application application);

        List<ApplicationModel> RetrieveApplicationsByChannelId(int channelId);
    }
}
