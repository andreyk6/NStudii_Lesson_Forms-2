using EmptyProject.Models;
using EmptyProject.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyProject.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        ApplicationContext db = new ApplicationContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateItemVM());
        }
        [HttpPost]
        public ActionResult Create(CreateItemVM item)
        {
            if(ModelState.IsValid)
            {
                var NewItem = new Models.Item()
                {
                    Name = item.Name,
                    Description=item.Description,
                    ImageURL=item.ImageUrl,
                    Price=item.Price,
                    StoreId=item.StoreId
                };
                db.Item.Add(NewItem);
                db.SaveChanges();

                return RedirectToAction("ItemInfo", new { Id = NewItem.Id });
            }
            return View(item);
        }

        public ActionResult Edit(Guid Id)
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
    }
}