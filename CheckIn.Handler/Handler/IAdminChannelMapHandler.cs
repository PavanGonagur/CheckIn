using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface IAdminChannelMapHandler
    {
        void AddAdminChannelMap(AdminChannelMap adminChannelMap);

        void DeleteAdminChannelMap(AdminChannelMap adminChannelMap);
    }
}
