using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    public class EmailUtility
    {
        public static string GetFormattedEmailUserName(string emailUserName)
        {
            string formattedEmailUserName;
            formattedEmailUserName = emailUserName.Split('+')[0];
            formattedEmailUserName = formattedEmailUserName.Replace(".", string.Empty);
            return formattedEmailUserName;
        } 
    }
}