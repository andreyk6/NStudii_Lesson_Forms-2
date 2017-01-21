using EmptyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Controllers
{
    public class StoreController : Controller
    {
        ApplicationContext _db = new ApplicationContext();
        // GET: Store

        public ActionResult Index()
        {
            return View(_db.Store.ToList());
        }
        

    }
}