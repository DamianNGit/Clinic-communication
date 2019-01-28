using mgrprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mgrprojekt.Security
{
    public class CustomAutorizeAtt:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(string.IsNullOrEmpty(SessionPersiter.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "PanelPracownika", action = "Index" }));
            }
            else
            {
                AccountsPracownikOb apo = new AccountsPracownikOb();
                CustomPrincipal cp = new CustomPrincipal(apo.find(SessionPersiter.Username));
                if(!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
        }
    }
}