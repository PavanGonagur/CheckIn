﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Web.Models.Admin;

    public interface IAdminChannelMapBusiness
    {
        void AddAdminChannelMap(AdminChannelMapModel userChannelMapModel);
    }
}