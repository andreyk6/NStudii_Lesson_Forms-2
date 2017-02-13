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
            if (Request.Cookies["token"] != null)
            {
                var tokenValue = Request.Cookies["token"].Value;

                var user = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue).User;

                if (user != null)
                {
                    return View(user);
                }
            }
            return new HttpNotFoundResult("User not found");
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(new CreateUserVM());
        }

        [HttpPost]
        public ActionResult Create(CreateUserVM userVM)
        {
            var usersCount = _db.User.FirstOrDefault((u) => u.Email == userVM.Email);
            var usersLoginsCount = _db.User.FirstOrDefault((u) => u.Login == userVM.Login);
            if (ModelState.IsValid)
                if (usersCount == null)
                    if (usersLoginsCount == null)
                    {
                        var user = new User()
                        {
                            Email = userVM.Email,
                            Login = userVM.Login,
                            Password = userVM.Password
                        };
                        var token = new Token()
                        {
                            Id = Guid.NewGuid(),
                            User = user,
                            ExpiresDate = DateTime.Now.AddDays(10),
                            Value = "token" + DateTime.Now + user.Login
                        };
                        user.Token = token;

                        _db.User.Add(user);
                        _db.Tokens.Add(token);

                        _db.SaveChanges();



                        return RedirectToAction("Login");
                    }
            userVM.Password = "";
            userVM.Password2 = "";

            return View(userVM);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginUserVM());
        }

        [HttpPost]
        public ActionResult Login(LoginUserVM userLoginVM)
        {
            //Поиск пользователя с такими данными
            var user = _db.User.FirstOrDefault(u => u.Login == userLoginVM.Login && u.Password == userLoginVM.Password);
            if (user == null)
            {
                return View(userLoginVM);
            }

            //Создаем токен или возвращаем существующий
            if (user.Token == null)
            {
                GenerateTokenAndSaveToDb(user);
            }
            else if (user.Token.ExpiresDate < DateTime.Now)
            {
                GenerateTokenAndSaveToDb(user);
            }

            Response.Cookies.Add(new System.Web.HttpCookie("token", user.Token.Value));

            return RedirectToAction("Index", "Home");
        }


        private void GenerateTokenAndSaveToDb(User user)
        {
            user.Token.ExpiresDate = DateTime.Now.AddDays(30);
            user.Token.Value = "token" + DateTime.Now + user.Login;
            _db.SaveChanges();
        }
    }
}