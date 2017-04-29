using EmptyProject.Models;
using EmptyProject.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Controllers
{
    public class ItemController : Controller
    {
        // GET: Items
        ApplicationContext db = new ApplicationContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(Guid storeId)
        {
            var vm = new CreateItemVM();
            vm.StoreId = storeId;
            return View(vm);
        }
        [HttpPost]
        public ActionResult Create(CreateItemVM item)
        {
            if (ModelState.IsValid)
            {
                var NewItem = new Models.Item()
                {
                    Name = item.Name,
                    Description = item.Description,
                    ImageURL = item.ImageUrl,
                    Price = item.Price,
                    StoreId = item.StoreId
                };
                db.Items.Add(NewItem);
                db.SaveChanges();

                return RedirectToAction("Read", new { Id = NewItem.Id });
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Read(Guid Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Item item = db.Items.Find(Id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpGet]
        public ActionResult Edit(Guid? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Item item = db.Items.Find(Id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            Item item = db.Items.Find(Id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            if(Id==null)
            {
                return HttpNotFound();
            }
            Item item = db.Items.Find(Id);
            db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}