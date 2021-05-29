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
    public class UserController : Controller
    {
        private readonly IUserManager userManager = new UserManagerLayer();
        public UserController()
        {

        }
       // public ActionResult Register()
       // {
       //     return View();
       //}
        [HttpPost]
        public ActionResult Register(User users)
        {
            try
            {
                var result = this.userManager.AddUserDetails(users);
                ViewBag.Message = "User registered successfully";
                return View();
            }
            catch (Exception)
            {
                return ViewBag.Message = "User registered unsuccessfully";
            }
        }

    }
}