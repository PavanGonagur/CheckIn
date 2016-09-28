using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Data.Entities;

    public interface ILocationBusiness
    {
        int AddLocation(Location location);

        void DeleteLocationn(Location location);

        Location RetrieveLocationById(int locationId);
    }
}
