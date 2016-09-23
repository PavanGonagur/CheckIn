﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Web.Business
{
    using CheckIn.Web.Models;

    public interface IAuthenticationBusiness
    {
        bool CheckPasswordHashMatches(AuthenticateAdminModel authenticateAdminModel);
    }
}
