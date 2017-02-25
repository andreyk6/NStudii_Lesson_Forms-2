using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmptyProject.Models;

namespace EmptyProject.Helpers
{
    public class AuthAttribute : AuthorizeAttribute
    {
        ApplicationContext _db = new ApplicationContext();

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var tokenValue = httpContext.Request.Cookies.Get("token");
            if (tokenValue == null)
            {
                return false;
            }

            var token = _db.Token.FirstOrDefault(t => t.Value == tokenValue.Value);
            if (token == null)
            {
                return false;
            }

            if (token.ExpirensDate <= DateTime.Now)
            {
                return false;
            }

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext) == false)
            {
                var routeParams = new RouteValueDictionary()
                {
                    {"controller", "user"},
                    {"action", "login"}
                };

                filterContext.Result = new RedirectToRouteResult(routeParams);
            }
        }
    }
}