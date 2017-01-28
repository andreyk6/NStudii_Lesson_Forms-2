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

    }
}