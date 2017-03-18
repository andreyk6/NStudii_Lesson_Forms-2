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
            
            return View();
        }

        public ActionResult Contacts ()
        {

            return View();
        }


    }
}