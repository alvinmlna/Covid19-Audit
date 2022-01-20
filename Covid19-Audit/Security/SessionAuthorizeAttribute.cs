using Covid19_BusinessLogic.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Covid19_Audit.Security
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session[SessionConstants.CURRENT_USER] != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary
                              {
                                   { "action", "Index" },
                                   { "controller", "Login" }
                              });
        }
    }
}