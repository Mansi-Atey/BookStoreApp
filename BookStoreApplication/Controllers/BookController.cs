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
    public class BookController : Controller
    {
        // GET: Book
        private readonly IBookManager bookManager = new BookManagerLayer();
        public BookController()
        {

        }
        public ActionResult GetAllBooks()
        {
           return View();
        }
        [HttpGet]
        public ActionResult GetAllBooks(Books book)
        {
            try
            {
                var result = this.bookManager.GellAllBooks();
                ViewBag.Message = "";
                return View(result);
               // return RedirectToAction("GetAllCart");
            }
            catch (Exception)
            {
                return ViewBag.Message = "";
            }
        }
    }
}