using EmptyProject.Models;
using EmptyProject.ViewModels;
using System.Web.Mvc;
using System;
using System.Linq;
using EmptyProject.ViewModels.User;

namespace EmptyProject.Controllers
{
    public class UserController : Controller
    {
        ApplicationContext _db = new ApplicationContext();

        public UserController()
        {
            Console.WriteLine("Ctor called");
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(_db.User.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateUserVM());
        }

        [HttpPost]
        public ActionResult Create(CreateUserVM userVM)
        {
            if (ModelState.IsValid &&
                _db.User.Select((u) => u.Email == userVM.Email).Count() == 0 &&
                _db.User.Select((u) => u.Login == userVM.Login).Count() == 0
                )
            {
                var user = new User()
                {
                    Email = userVM.Email,
                    Login = userVM.Login,
                    Password = userVM.Password
                };
                _db.User.Add(user);
                _db.SaveChanges();

                return RedirectToAction("Login");
            }
            else
            {
                userVM.Password = "";
                userVM.Password2 = "";

                return View(userVM);
            }
        }
    }
}