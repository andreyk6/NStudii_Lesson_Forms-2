using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyProject.Helpers;
using EmptyProject.Models;

namespace EmptyProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db = new ApplicationContext();

        // GET: Home
        [Auth]
        public ActionResult Index()
        {
            string token = Request.Cookies.Get("token").Value;
            var user = _db.Token.FirstOrDefault(t => t.Value == token).User;
            return View(user);
        }

        public ActionResult ViewRoles()
        {
            var roles = _db.Role;

            return View(roles);
        }
    }
}