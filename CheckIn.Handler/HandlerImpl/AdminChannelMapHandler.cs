using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using System.Data.Entity.Migrations;

    using CheckIn.Data;
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;

    public class AdminChannelMapHandler : IAdminChannelMapHandler
    {
        private readonly CheckInDb checkInDb;

        public AdminChannelMapHandler()
        {
            this.checkInDb = new CheckInDb();
        }
        public void AddAdminChannelMap(AdminChannelMap adminChannelMap)
        {
            this.checkInDb.AdminChannelMaps.AddOrUpdate(adminChannelMap);
            this.checkInDb.SaveChanges();
        }

        public void DeleteAdminChannelMap(AdminChannelMap adminChannelMap)
        {
            this.checkInDb.AdminChannelMaps.Remove(adminChannelMap);
            this.checkInDb.SaveChanges();
        }
    }
}
