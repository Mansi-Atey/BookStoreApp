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
        [HttpPost]
        public JsonResult AddBook(Books book)
        {
            try
            {
                var result = this.bookManager.AddBook(book);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added", Data = result });
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "sucessfully";
            }
        }
        [HttpPost]
        public ActionResult DeleteBook(int bookID)
        {
            try
            {
                var result = this.bookManager.DeleteBook(bookID);
                if (result > 0)
                {
                    return View();
                    // return Json(new { status = true, Message = "Book added", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "sucessfully";
            }
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