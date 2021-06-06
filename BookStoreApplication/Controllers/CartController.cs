
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
    public class CartController : Controller
    {
        // GET: Cart
        private readonly ICartManager cartManager = new CartManager();
        public CartController()
        {

        }
        //public ActionResult AddToCart()
        //{
        //    return View();
        //}

        [HttpPost]
        public JsonResult AddToCart(Cart cartModel)
        {
            try
            {
                var result = this.cartManager.AddCartDetails(cartModel);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added to cart", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to cart", Data = result });
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "sucessfully";
            }
        }
        [HttpPost]
        public ActionResult DeleteCartByCartId(int cartId)
        {
            try
            {
                var result = this.cartManager.DeleteCartByCartId(cartId);
                if (result > 0)
                {
                    return View();
                    // return Json(new { status = true, Message = "Book added to cart", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to cart", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "sucessfully";
            }
        }
            //public ActionResult GetAllCart()
            //{
            //    return View();
            //}
            [HttpGet]
        public ActionResult GetAllCart()
        {
            try
            {
                var result = this.cartManager.GellAllCart();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex )
            {
               throw new Exception(ex.Message);
               //return ViewBag.Message = "";
            }
        }
    }
}