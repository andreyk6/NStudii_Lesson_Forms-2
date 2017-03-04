using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmptyProject.Models;


namespace EmptyProject.Help
{
    public class AnonymousOnlyAttribute : AuthorizeAttribute
    {
        ApplicationContext _db = new ApplicationContext();

        protected override bool AuthorizeCore(HttpContextBase httpContext)

        {
            var tokenCookie = httpContext.Request.Cookies.Get("token");
            if (tokenCookie != null)
            {
                var tokenValue = httpContext.Request.Cookies.Get("token").Value;

                if (tokenValue == null)
                {
                    return true;

                }


                var token = _db.Token.FirstOrDefault(t => t.Value == tokenValue);
                if (token == null)
                {
                    return true;
                }


                if (token.ExpiresDate <= DateTime.Now)
                {
                    return true;
                }

                return false;
            }
            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext) == true)
            {
                var routeParams = new RouteValueDictionary()
                {
                    { "controller","home" },
                    {"action", "index" }
                };

                filterContext.Result = new RedirectToRouteResult(routeParams);
            }
        }
    }
}
