﻿using EmptyProject.Models;
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
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginUserVM());
        }
        [HttpPost]
        public ActionResult Login(LoginUserVM userLoginVM)
        {
            var user = _db.User.FirstOrDefault(u => u.Login == userLoginVM.Login && u.Password == userLoginVM.Password);
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
            user.Token.ExpirensDate = DateTime.Now.AddDays(30);
            user.Token.Value = "token" + DateTime.Now + user.Login;
            _db.SaveChanges();
        }
    }
}