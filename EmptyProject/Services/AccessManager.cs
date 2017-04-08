using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmptyProject.Models;

namespace EmptyProject.Services
{
    public static class AccessManager
    {
        private static ApplicationContext _db;

            static AccessManager()
        {
            _db = new ApplicationContext();
        }


        public static bool IsAuthorized()

        {
            var user = GetCurrentUser();
            if (user == null)
                return false;

            if (user.Token.ExpiresDate <= DateTime.Now)
                return false;

            return true;
        }

        private static Token GetToken()
        {
          System.Web.HttpCookie tokenCookies = HttpContext.Current.Request.Cookies.Get("token");
          if (tokenCookies == null)
            return null;
            
          string tokenValue = tokenCookies.Value;
          if (tokenValue == null)
              return null;
            
            Token token = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue);
            if (token == null)
                 return null;
            
               return token;
        }
 
         public static User GetCurrentUser()
         {
             var token = GetToken();
             if (token == null)
                 return null;
 
             return token.User; 
        }
    }
}