using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Dashboard
{
    public class RulesModel
    {
        public DeviceRulesModel DeviceRulesModel { get; set; }

        public AppRulesModel AppRulesModel { get; set; }

        public EmailRulesModel EmailRulesModel { get; set; }

        public NetworkRulesModel NetworkRulesModel { get; set; }
    }
}