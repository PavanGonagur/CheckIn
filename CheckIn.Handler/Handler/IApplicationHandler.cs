using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IApplicationHandler
    {
        void DeleteApplication(Application application);

        Application RetrieveApplicationById(int applicationId);

        List<Application> RetrieveApplicationsByChannelId(int channelId);

        int AddOrUpdateApplication(Application application);
    }
}
