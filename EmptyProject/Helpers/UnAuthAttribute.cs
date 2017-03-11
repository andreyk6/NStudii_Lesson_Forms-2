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
    public class UnAuthAttribute : AuthorizeAttribute
    {
        ApplicationContext _db = new ApplicationContext();
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            System.Web.HttpCookie tokenCookies = httpContext.Request.Cookies.Get("token");
            if (tokenCookies != null)
            {
                string tokenValue = httpContext.Request.Cookies.Get("token").Value;
                if (tokenValue == null)
                {
                    return true;
                }


                var token = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue);
                if (token == null)
                {
                    return true;
                }
                var user = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue).User;
                if (user != null)
                {
                    if (DateTime.Now >= user.Token.ExpirensDate)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}