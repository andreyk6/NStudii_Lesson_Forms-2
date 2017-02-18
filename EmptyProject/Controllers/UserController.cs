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
            string token = Request.Cookies["token"].Value;
            if(token==null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var token1 = _db.Token.;
            }
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

        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserLoginVM());
        }

        [HttpPost]
        public ActionResult Login(UserLoginVM userVm)
        {
            var user = _db.User.FirstOrDefault(
                u => u.Login == userVm.Login && u.Password == userVm.Password
            );
            if(user==null)
            {
                return View(new UserLoginVM());
            }
            else
            {
                GenerateToken(user);
                Response.Cookies.Add(new System.Web.HttpCookie("token",user.token.token));
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult GenerateToken(User user)
        {
            Token token = new Token(user.Login + DateTime.Today, DateTime.Today.AddDays(30), user.Id, Guid.NewGuid());
            user.TokenId = token.Id;
            _db.SaveChanges();
            return View();
        }

    }
}