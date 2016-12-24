using EmptyProject.Models;
using EmptyProject.ViewModels;
using System.Web.Mvc;
using System;

namespace EmptyProject.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();

        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateUserViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                ApplicationContext db = new ApplicationContext();

                db.User.Add(new User()
                {
                    Id =  Guid.NewGuid(),
                    Email = user.Email,
                    Login = user.Login,
                    Password = user.Password
                });
            }
            return View(user);
        }

    }
}