using EmptyProject.Models;
using EmptyProject.ViewModels.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Controllers
{
    public class BrandController : Controller
    {
        public ApplicationContext db = new ApplicationContext();
        // GET: Brand
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateBrandVM());
        }

        [HttpPost]
        public ActionResult Create(CreateBrandVM brand)
        {
            if (ModelState.IsValid)
            {
                var newbrand = new Brand()
                {
                    Description = brand.Description,
                    Name = brand.Name,
                    LogoURL = brand.LogoURL,
                    UserId = brand.UserID
                };
                db.Brand.Add(newbrand);
                db.SaveChanges();
                return RedirectToAction("BrandInfo", new { Id = newbrand.Id });
            }
            return View(brand);
        }
    }
}