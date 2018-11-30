using Movie.Models;
using Movie.Presentation.Models;
using Movie.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private CustomerService customerService;
        //public static int currentSession;
        public LoginController()
        {
            customerService = new CustomerService();
        }
        // GET:/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = customerService.Login(model.Email, model.Password);
                if (result == 1)
                {

                    var customer = customerService.GetCustomerLogin(model.Email);
                    Session["Customer"] = customer;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Địa chỉ Email hoặc mật khẩu không đúng.");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Logout()
        {

            Session.Remove("Customer");
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerService.Add(customer);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("","Không thể tạo tài khoản mới");
            }
            return View("Index");
        }
        public JsonResult CheckEmail(string email)
        {
            var result = customerService.GetAll().Where(r => r.Email == email).Count() > 0 ? false : true;
            return Json(result, JsonRequestBehavior.AllowGet);

            
        }
    }
}