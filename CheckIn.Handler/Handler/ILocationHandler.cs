using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.Handler
{
    using CheckIn.Data.Entities;

    public interface ILocationHandler
    {
        int AddOrUpdateLocation(Location location);

        List<Location> RetrieveLocationsByChannelId(int channelId);

        Location RetrieveLocationById(int locationId);

        void DeleteLocation(Location location);
    }
}
