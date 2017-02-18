using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyProject.Models;

namespace EmptyProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db = new ApplicationContext();

        // GET: Home
        public ActionResult Index()
        {
            string token = Request.Cookies.Get("token").Value;
            if (token == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                var user = _db.Token.FirstOrDefault(t => t.Value == token).User;
                return View(user);
            }
            return View();
        }

        public ActionResult ViewRoles()
        {
            var roles = _db.Role;

            return View(roles);
        }
    }
}