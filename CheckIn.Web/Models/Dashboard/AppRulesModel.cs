using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Dashboard
{
    public class AppRulesModel
    {
        public bool BlacklistedApp { get; set; }

        public bool MandatoryApp { get; set; }

        public bool WhitelistedApp { get; set; }
    }
}