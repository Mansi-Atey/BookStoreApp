using BookStoreManagerLayer;
using BookStoreManagerLayer.InterfaceManager;
using BookStoreModelLayer;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreApplication.Controllers
{
    //[Authorize]
    public class BookController : Controller
    {
        // GET: Book
        private readonly IBookManager bookManager;
        public BookController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
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
                if (result == true)
                {
                  //  return View();
                     return Json(new { status = true, Message = "Book added", Data = result });
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
        [HttpPost]
        public ActionResult UploadImage(int BookID, HttpPostedFileBase image)
        {
            try
            {
                var imageUpload = CloudImageLink(image);
                bool result = this.bookManager.UploadImage(BookID, imageUpload);
                if (result == true)
                {
                    return Json(new { status = true, Message = "Book image added ", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "image not added " });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private string CloudImageLink(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            var filepath = file.InputStream;
            string uniquename = Guid.NewGuid().ToString() + "_" + file.FileName;
            Account account = new Account("daksjksop", "168387554676626", "j8q917cakxOGXNxt34NWT9xHMnM");
            Cloudinary cloud = new Cloudinary(account);
            var uploadparam = new ImageUploadParams()
            {
                File = new FileDescription(uniquename, filepath)
            };
            var uploadResult = cloud.Upload(uploadparam);
            return uploadResult.Url.ToString();
        }
    }
}