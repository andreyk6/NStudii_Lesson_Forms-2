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
            string tokenValue = Request.Cookies["token"].Value;
            if (tokenValue == null)
            {
                return RedirectToAction("Login");
            }

            Token token = _db.Token.FirstOrDefault(t => t.token == tokenValue);
            if (token == null)
            {
                return RedirectToAction("Login");
            }

            var user = _db.User.FirstOrDefault(u => u.TokenId == token.Id);

            if (user != null)
            {
                if (DateTime.Today > token.ExpiresDate)
                {
                    return RedirectToAction("Login");
                }
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Create()
        {
            //var token1 = _db.Token.FirstOrDefault();
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
            return View(new LoginUserVM());
        }

        [HttpPost]
        public ActionResult Login(LoginUserVM userVm)
        {
            var user = _db.User.FirstOrDefault(
                u => u.Login == userVm.Login && u.Password == userVm.Password
            );
            if (user == null)
            {
                return View(new LoginUserVM());
            }
            else
            {
                GenerateToken(user);
                Response.Cookies.Add(new System.Web.HttpCookie("token", user.token.token));
                return RedirectToAction("Index");
            }

        }

        public ActionResult GenerateToken(User user)
        {
            Token token = new Token(user.Login + DateTime.Today, DateTime.Today.AddDays(30), user.Id, Guid.NewGuid());
            user.TokenId = token.Id;
            _db.Token.Add(token);
            _db.SaveChanges();
            return View();
        }

    }
}