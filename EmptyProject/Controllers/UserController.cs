using EmptyProject.Models;
using EmptyProject.ViewModels;
using System.Web.Mvc;
using System;
using System.Linq;
using EmptyProject.ViewModels.User;
using EmptyProject.Helper;

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
        [Auth]
        public ActionResult Index(User user)
        {
            string token = Request.Cookies["token"].Value;
            if (token == null)
            {
                return RedirectToAction("Login");
            }
            return View();
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
               !_db.Users.Any((u) => u.Email == userVM.Email) &&
                !_db.Users.Any((u) => u.Login == userVM.Login))
            {
                var user = new User()
                {
                    Email = userVM.Email,
                    Login = userVM.Login,
                    Password = userVM.Password
                };
                _db.Users.Add(user);
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
        [UnAuth]
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginUserVM());
        }
        [HttpPost]
        public ActionResult Login(LoginUserVM userLoginVM)
        {
            var user = _db.Users.FirstOrDefault(u => u.Login == userLoginVM.Login && u.Password == userLoginVM.Password);
            if (user == null)
            {
                return View(userLoginVM);
            }
            if (user.Token == null)
            {
                GenerateTokenAndSaveToDb(user);
            }
            Response.Cookies.Add(new System.Web.HttpCookie("token", user.Token.Value));
            return RedirectToAction("Index", "Home");
        }

        private void GenerateTokenAndSaveToDb(User user)
        {
            user.Token = new Token();
            user.Token.Id = Guid.NewGuid();
            user.Token.ExpiresDate = DateTime.Now.AddDays(30);
            user.Token.Value = "token" + DateTime.Now + user.Login;
            _db.SaveChanges();
        }
        public ActionResult AccountINfo()
        {
            return View();
        }
    }

}