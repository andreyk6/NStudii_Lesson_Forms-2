using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyProject.Models;
using EmptyProject.ViewModels.Store;

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
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateStoreVM());
        }

        [HttpPost]
        public ActionResult Create(CreateStoreVM storeVM)
        {
            if (ModelState.IsValid)
            {
                var store = new Store()
                {
                    Name = storeVM.Name,
                    Description = storeVM.Description,
                    BrandId = storeVM.BrandId
                };
                _db.Store.Add(store);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(storeVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Store store = _db.Store.Find(id);
            if (store != null)
            {
                return View(store);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Store store)
        {
            _db.Entry(store).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            Store s = _db.Store.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Store s = _db.Store.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            _db.Store.Remove(s);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}