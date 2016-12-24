using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyProject.Models;

namespace EmptyProject.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _db = new ApplicationContext();

        // GET: Home
        public ActionResult Index()
        {
            var role1 = new Role();
            role1.Id = Guid.NewGuid();
            role1.Name = "Admin";

            var role2 = new Role();
            role2.Id = Guid.NewGuid();
            role2.Name = "User";

            var user1 = new User();
            user1.Id = Guid.NewGuid();
            user1.Login = "login1";
            user1.Password = "password";
            user1.Email = "mail@gmail.com";
            user1.Roles = new[] { role1, role2 };

            var user2 = new User();
            user2.Id = Guid.NewGuid();
            user2.Login = "login2";
            user2.Password = "password";
            user2.Email = "mail2@gmail.com";
            user2.Roles = new[] { role2 };

            _db.Role.AddRange(new[] { role1, role2 });
            _db.User.AddRange(new[] { user1, user2 });

            _db.SaveChanges();

            return View();
        }

        public ActionResult ViewRoles()
        {
            var roles = _db.Role;

            return View(roles);
        }
    }
}