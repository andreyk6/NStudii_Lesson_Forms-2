using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyProject.Models;
using EmptyProject.Helper;

namespace EmptyProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db = new ApplicationContext();
        
        // GET: Home
        public ActionResult Index()
        {
            string token = Request.Cookies.Get("token").Value;
                var user = _db.Token.FirstOrDefault(t => t.Value == token).User;
            return View();
        }




        public ActionResult About()
        {
            ViewBag.Message = "My application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    

    public ActionResult ViewRoles()
        {
            var roles = _db.Role;

            return View(roles);
        }
    }
}