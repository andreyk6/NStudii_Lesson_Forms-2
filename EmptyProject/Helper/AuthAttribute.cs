using EmptyProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EmptyProject.Helper
{
    public class AuthAttribute : AuthorizeAttribute
    {
        ApplicationContext _db = new ApplicationContext();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var Cookietoken = httpContext.Request.Cookies.Get("token");
            if (Cookietoken != null)
            {
                string tokenValue = httpContext.Request.Cookies.Get("token").Value;
                if (tokenValue == null)
                {
                    return false;
                }


                var token = _db.Token.FirstOrDefault(t => t.Value == tokenValue);
                if (token == null)
                {
                    return false;
                }
                var user = _db.Token.FirstOrDefault(t => t.Value == tokenValue).User;
                if (user != null)
                {
                    if (DateTime.Now >= user.Token.ExpirensDate)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext) == false)
            {
                var routeParams = new RouteValueDictionary()
                {
                    { "controller","user"},
                    { "action","login"}
                    };

                filterContext.Result = new RedirectToRouteResult(routeParams);
            }
        }

    }
}