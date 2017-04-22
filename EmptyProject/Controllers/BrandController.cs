﻿using EmptyProject.Models;
using EmptyProject.Services;
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
            Guid userId = AccessManager.GetCurrentUser().Id;

            List<Brand> brands = db.Brands
            .Where(b => b.UserId == userId)
            .ToList();

            return View(brands);
        }
        
        // GET: Brand
        [HttpGet]
        public ActionResult Create()
        {
            var brandVM = new CreateBrandVM();
            brandVM.UserID = AccessManager.GetCurrentUser().Id;
            return View(brandVM);
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
                db.Brands.Add(newbrand);
                db.SaveChanges();
                return RedirectToAction("Info", new { Id = newbrand.Id });
            }
            return View(brand);
        }


        public ViewResult Info(Guid id )
        {
            Brand b = db.Brands.Find(id);
            return View(b);
        }

        public ActionResult Delete(Guid id )
        {
            Brand b = db.Brands.Find(id);
            if (b != null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id )
        {
            Brand b = db.Brands.Find(id);
                if (b == null)
            {
                return HttpNotFound();
            }
            db.Brands.Remove(b);
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
            Brand brand = db.Brands.Find(id);
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