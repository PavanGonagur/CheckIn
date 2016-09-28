using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.BusinessImpl
{
    using CheckIn.Data.Entities;
    using CheckIn.Handler.Handler;
    using CheckIn.Handler.HandlerImpl;
    using CheckIn.Web.Business;
    using CheckIn.Web.Models.Admin;

    public class AdminChannelMapBusiness : IAdminChannelMapBusiness
    {
        private readonly IAdminChannelMapHandler adminChannelMapHandler;

        public AdminChannelMapBusiness()
        {
            this.adminChannelMapHandler = new AdminChannelMapHandler();
        }
        public void AddAdminChannelMap(AdminChannelMapModel userChannelMapModel)
        {
            var userEntity = new AdminChannelMap()
            {
               AdminId = userChannelMapModel.AdminId,
               ChannelId = userChannelMapModel.ChannelId
            };

            this.adminChannelMapHandler.AddAdminChannelMap(userEntity);
        }
    }
}