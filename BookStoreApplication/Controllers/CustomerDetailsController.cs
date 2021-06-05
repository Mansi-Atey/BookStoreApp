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
        private readonly ICustomerDetailsManager customerManager = new CustomerDetailsManager();
        public CustomerDetailsController()
        {

        }
        // GET: CustomerDetails

        [HttpPost]
        public JsonResult AddCustomerDetails(CustomerDetails customers)
        {
            try
            {
                var result = this.customerManager.AddCustomerDetails(customers);
                if (result != null)
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

    }
}