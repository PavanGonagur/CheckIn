using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using CheckIn.Data.Entities;

namespace CheckIn.Web.Utilities
{
    public static class SessionUtility
    {
        private const string CURRENT_ADMIN = "CurrentAdmin";

        public static Admin CurrentAdmin
        {
            get
            {
                // Make sure that a context exists 
                Debug.Assert(HttpContext.Current != null, "This control must be invoked within an HTTP context.");

                if (HttpContext.Current == null) throw new NullReferenceException("HTTP context is null");

                // return the setting
                Admin result = null;
                try
                {
                    if (HttpContext.Current.Session[CURRENT_ADMIN] != null)
                    {
                        result = (Admin) HttpContext.Current.Session[CURRENT_ADMIN];
                    }
                }
                catch (Exception exc)
                {
                    throw new AuthenticationException();
                }

                return result;
            }
            set
            {
                HttpContext.Current.Session[CURRENT_ADMIN] = value;
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                if (CurrentAdmin != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}