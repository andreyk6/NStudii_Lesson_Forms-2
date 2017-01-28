using EmptyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Controllers
{
    public class BrandController : Controller
    {
        ApplicationContext _db = new ApplicationContext();
        // GET: Brand
        public ActionResult Index()
        {
            return View(_db.Brand.ToList());
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (CreateBrandVM user)
        {
            if (ModelState.IsValid)
            {
                var Brand = new Brand

            }
        }
    }
}