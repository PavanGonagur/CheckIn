using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Models.Dashboard
{
    public class DeviceRulesModel
    {
        public bool CompromisedDevice { get; set; }

        public bool DeviceHasNotCheckedIn { get; set; }

        public bool DeviceNonCompliant { get; set; }
    }
}