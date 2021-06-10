using BookStoreManagerLayer;
using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishListManager wishListManager;
        public WishListController(IWishListManager wishListManager)
        {
            this.wishListManager = wishListManager;
        }
        // GET: WishList
        [HttpPost]
        public JsonResult AddToWishList(WishList wishList)
        {
            try
            {
                var result = this.wishListManager.AddToWishList(wishList);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added to wishList", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to wishList", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "sucessfully";
            }
        }
        [HttpGet]
        public ActionResult ViewWishListDetails()
        {
            try
            {
                var result = this.wishListManager.ViewWishListDetails();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}