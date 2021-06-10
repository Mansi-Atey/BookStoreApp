using BookStoreManagerLayer;
using BookStoreManagerLayer.InterfaceManager;
using BookStoreManagerLayer.Manager;
using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        public ActionResult Register()
        {
           
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User users)
        {
            try
            {
                var result = this.userManager.AddUserDetails(users);
                ViewBag.Message = "User registered successfully";
                // return View();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return ViewBag.Message = "User registered unsuccessfully";
            }
        }
       // [Authorize]
        [HttpPost]
        public ActionResult Login(Login login)
        {
            try
            {
                var result = this.userManager.Login(login);
                ViewBag.Message = "User Login successfully";
                return View();
            }
            catch (Exception)
            {
                return ViewBag.Message = "User Login unsuccessfully";
            }
        }
    }
}