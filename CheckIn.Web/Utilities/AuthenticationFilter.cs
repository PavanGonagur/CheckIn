using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;

namespace CheckIn.Web.Utilities
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionUtility.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"controller", "Login" },
                        {"action", "Index" },
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl }
                    }
                );
            }
        }
    }
}