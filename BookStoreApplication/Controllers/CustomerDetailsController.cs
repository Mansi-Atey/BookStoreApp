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
    public class CustomerDetailsController : Controller
    {
        private readonly ICustomerDetailsManager customerManager;
        public CustomerDetailsController(ICustomerDetailsManager customerManager)
        {
            this.customerManager = customerManager;
        }
        // GET: CustomerDetails

        [HttpPost]
        public ActionResult AddCustomerDetails(CustomerDetails customers)
        {
            try
            {
                var result = this.customerManager.AddCustomerDetails(customers);
                if (result > 0)
                {
                    return Json(new { status = true, Message = "Customer added..!!!", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Customer not added...!!", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "sucessfully";
            }
        }
        [HttpPost]
        public ActionResult UpdateCustomerDetails(int CustomerId,CustomerDetails info)
        {
            try
            {
                var result = this.customerManager.UpdateCustomerDetails(CustomerId,info);
                if (result !=null)
                {
                    return Json(new { status = true, Message = "Customer added..!!!", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Customer not added...!!", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "sucessfully";
            }
        }
        [HttpGet]
        public ActionResult GetAllCustomerDetails(int UserId)
        {
            try
            {
                //int UserId = 1;
                var result = this.customerManager.GetAllCustomerDetails(UserId);
                //ViewBag.Message = "";
                if (result != null)
                {
                    return Json(new { status = true, Message = "Customers details fetched successfully ..!!!", Data = result }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = false, Message = "No customer present..!!", Data = result }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "";
            }
        }
    }
}