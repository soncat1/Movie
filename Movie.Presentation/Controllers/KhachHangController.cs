using Movie.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class KhachHangController : Controller
    {
        private CustomerService customerService;
        public KhachHangController()
        {
            customerService = new CustomerService();
        }
        // GET: Customer
        public ActionResult Index()
        {
            if(Session["Customer"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var customerId = ((Customer)Session["Customer"]).CustomerId;
                return View(customerService.GetCustomer(customerId));
            }
            
        }
        [HttpPost]
        public ActionResult Index(Customer customer,string newPassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customer.CustomerId = (Session["Customer"] as Customer).CustomerId;
                    if(String.IsNullOrEmpty(newPassword))
                    {
                        customer.Password = (Session["Customer"] as Customer).Password;
                    }
                    else
                    {
                        customer.Name= (Session["Customer"] as Customer).Name;
                        customer.Address = (Session["Customer"] as Customer).Address;
                        customer.DateOfBirth= (Session["Customer"] as Customer).DateOfBirth;
                        customer.Email= (Session["Customer"] as Customer).Email;
                        customer.Type= (Session["Customer"] as Customer).Type;
                        customer.Password = newPassword;
                    }
                    customerService.Update(customer);
                    Session["Customer"] = customer;
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin khách hàng!");
            }
            return View(customer);
        }

        public JsonResult CheckPassword(string password)
        {
            var result = password == (Session["Customer"] as Customer).Password ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);


        }

    }
}