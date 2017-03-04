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
            var tokenValue = httpContext.Request.Cookies.Get("token");

            if (tokenValue == null)
            {
                return true;

            }


            var token = _db.Token.FirstOrDefult(t => t.Value == tokenValue.Value);
            if (token == null)
            {
                return true;
            }


            if (token.ExpirensDate <= DateTime.Now)
            {
                return true;
            }

            return false;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext) == true)
            {
                var routeParams = new RouteValueDictionary()
                {
                    { "controller","user" },
                    {"action", "login" }
        };

                filterContext.Result = new RedirectToRouteResult(routeParams);

            }
        }
    }
}
      