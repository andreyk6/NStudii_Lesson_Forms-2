using EmptyProject.Models;
using EmptyProject.ViewModels.Brand;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Controllers
{
    public class BrandController : Controller
    {
        public ApplicationContext db = new ApplicationContext();


        public ActionResult Index()
        {
            List<Brand> brands = db.Brand.ToList();
            return View(brands);
        }
        
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


        public ViewResult Read(Guid id )
        {
            Brand b = db.Brand.Find(id);
            return View();
        }

        public ActionResult Delete(Guid id )
        {
            Brand b = db.Brand.Find(id);
            if (b != null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id )
        {
            Brand b = db.Brand.Find(id);
                if (b == null)
            {
                return HttpNotFound();
            }
            db.Brand.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Brand brand = db.Brand.Find();
            if ( brand != null)
            {
                return View(brand);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            db.Entry(brand).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}