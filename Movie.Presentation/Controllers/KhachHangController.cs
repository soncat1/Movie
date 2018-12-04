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
        public ActionResult Index(Customer customer)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    customer.CustomerId = (Session["Customer"] as Customer).CustomerId;
                    customer.Password = (Session["Customer"] as Customer).Password;
                    customerService.Update(customer);
                    return RedirectToAction("Index","KhachHang");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Không thể thay đổi thông tin khách hàng!");
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPassword,string newPassword)
        {
            Customer customer = new Customer();
            var customerId = (Session["Customer"] as Customer).CustomerId;
            customer = customerService.GetCustomer(customerId);
            var result = oldPassword == customer.Password ? true : false;
            if(result==true)
            {
                try
                {
                    customer.Password = newPassword;
                    customerService.Update(customer);
                    return Content("Đổi mật khẩu thành công!");
                }
                catch (DataException ex)
                {

                    throw ex;
                }
                
            }
            else
            {
                return Content("Mật khẩu cũ không đúng!");
            }
        }

    }
}